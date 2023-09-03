using Microsoft.AspNetCore.Mvc;

namespace Home_Work_8_MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View("Index");
    }

    public IActionResult Task1()
    {
        // return Content(Environment.OSVersion.ToString());
        return View("Task1");
    }

    public IActionResult Task2()
    {
        return View("Task2");
    }

    public IActionResult About()
    {
        return View("About");
    }

    public IActionResult News()
    {
        return View("News");
    }

    public IActionResult Gallery()
    {
        return View("Gallery");
    }
}