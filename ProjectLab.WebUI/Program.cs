using BundlerMinifier.TagHelpers;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ProjectLab.WebUI.Infrastructures;
using WebMarkupMin.AspNetCore3;

var builder = WebApplication.CreateBuilder(args); 
var configuration = builder.Configuration.AddJsonFile("appsettings.json",optional: false).Build();  

///
var services = builder.Services;
{
    services.AddLogging(options =>
    {
        options.AddDebug();
        options.AddConsole();
        options.AddSeq(configuration.GetSection("Seq"));
    });

    services.AddControllersWithViews().AddNToastNotifyToastr(new ToastrOptions
    {
        CloseButton = true,
        PositionClass = ToastPositions.BottomRight

    }).AddRazorRuntimeCompilation();

    services.AddBundles(options =>
    {
        options.AppendVersion = true;
        options.UseBundles = false;
        options.UseMinifiedFiles = false;
    });
    services.AddWebMarkupMin(options =>
    {
        options.AllowMinificationInDevelopmentEnvironment = false;
        options.AllowCompressionInDevelopmentEnvironment  = false;

    }).AddHtmlMinification();

    services.AddScoped<IAlert, Alert>();

    services.AddDbContext<AppDataContext>(options =>
    {
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
    });
}

///
var app = builder.Build();
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseWebMarkupMin();
    app.UseAuthorization();
    app.UseNToastNotify();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
