using Microsoft.AspNetCore.Mvc;

namespace Home_Work_9_MVC.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}