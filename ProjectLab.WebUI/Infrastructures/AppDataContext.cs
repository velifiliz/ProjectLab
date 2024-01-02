using Microsoft.EntityFrameworkCore;

namespace ProjectLab.WebUI.Infrastructures;

public class AppDataContext : DbContext
{
    public AppDataContext() : base() { }

    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlServer("");
        }
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {

        base.ConfigureConventions(builder);
    }

    public DbSet<Person> Persons { get; set; }

}
