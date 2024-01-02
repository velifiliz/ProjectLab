using ProjectLab.WebUI.Infrastructures;

namespace ProjectLab.WebUI.Controllers;
public class HomeController(IAlert alert  ,ILogger<HomeController> logger , AppDataContext context) : Controller
{ 
    public IActionResult Index()
    {
 
        var model = new Person
        {
            Id = 1,
            Firstname = "Deneme",
            Lastname = "Proje",
        };
        logger.Log(LogLevel.Error , "Burda Bir Hata Meydana Geldi");

        //context.Persons.Add(model);
        //context.SaveChanges();

        var p = context.Persons.ToList();


        return View(model);
    }

    public IActionResult About()
    {
        return View();
    }

    [HttpPost]
    public string PersonDelete(int Id)
    {
        alert.Info("Merhaba Ben Server Side Tarafından Gönderilen Bir Alert 'im");
        return $"Silme İşlemi Başarıyla Gereçkleşti Silinen Person Id : {Id}";
    }
}