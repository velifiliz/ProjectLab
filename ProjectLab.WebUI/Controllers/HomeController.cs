using ProjectLab.WebUI.Infrastructures;

namespace ProjectLab.WebUI.Controllers;
public class HomeController(IAlert alert  ,ILogger<HomeController> logger , IAppDataServiceAsync service) : Controller
{ 
    public async Task<IActionResult> Index()
    {
         
         var get = await service.AsSqlGetAsync<Person>("SELECT * FROM Person WHERE Id = @Id" , new {Id =  10});
         var getAll = await service.AsSqlGetAllAsync<Person>("SELECT * FROM Person");

        return View();
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