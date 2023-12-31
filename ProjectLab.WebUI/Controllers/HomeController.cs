using NToastNotify;

namespace ProjectLab.WebUI.Controllers;
public class HomeController(IToastNotification toastNotification , ILogger<HomeController> logger) : Controller
{ 
    public IActionResult Index()
    {
        toastNotification.AddInfoToastMessage("Merhaba Ben Home Controller İçinden Geldim" , new ToastrOptions
        {
            Title = "Bilgi",
             
        });
        var model = new Person
        {
            Id = 1,
            Firstname = "Veli",
            Lastname = "Filiz",
        };
        logger.Log(LogLevel.Error , "Burda Bir Hata Meydana Geldi");
        return View(model);
    }

    public IActionResult About()
    {
        return View();
    }
}