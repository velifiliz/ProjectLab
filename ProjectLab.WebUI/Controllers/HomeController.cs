using ProjectLab.WebUI.Infrastructures;

namespace ProjectLab.WebUI.Controllers;
public class HomeController(IAlert alert  ,ILogger<HomeController> logger , IAppDataServiceAsync service) : Controller
{ 
    public async Task<IActionResult> Index()
    {
 
        var model = new Person
        {
            Id = 1,
            Firstname = "sdsdsdsd",
            Lastname = "sdsdsdsd",
        };
        logger.Log(LogLevel.Error , "Burda Bir Hata Meydana Geldi");

          var add = await service.RemoveAsync(model,true);

          var get = await service.GetAllAsync<Person>();


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