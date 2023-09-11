using Microsoft.AspNetCore.Mvc;
namespace Home_Work_13_MVC.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}