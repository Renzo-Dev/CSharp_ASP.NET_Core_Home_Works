using Microsoft.AspNetCore.Mvc;

namespace Home_Work_12.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}