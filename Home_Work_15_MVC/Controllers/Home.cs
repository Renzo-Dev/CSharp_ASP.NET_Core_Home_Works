using Home_Work_15_MVC.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Home_Work_15_MVC.Controllers;

[AddHeader("Hello", "I'Am Dan Koshevoy")]
[BrowserInfoFilter]
[ServiceFilter(typeof(ThrottlingFilter))]
[Controller]
public class Home : Controller
{
    [SetCookie("LastVisit", 30)]
    public IActionResult Index()
    {
        return View();
    }
}