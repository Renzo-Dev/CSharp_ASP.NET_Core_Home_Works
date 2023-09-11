using Microsoft.AspNetCore.Mvc;

namespace Home_Work_12_MVC.Controllers;

public class HomeController : Controller
{
    // GET
    [Route("/")]
    [Route("/Task1")]
    public IActionResult Index()
    {
        return View("Task1");
    }

    [Route("/Task2")]
    public IActionResult Task2()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(string name, int age)
    {
        ViewBag.Name = name;
        ViewBag.Age = Convert.ToString(age);
        return View("Task2");
    }
}