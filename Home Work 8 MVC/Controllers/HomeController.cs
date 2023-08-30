using Microsoft.AspNetCore.Mvc;

namespace Home_Work_8.Controllers;

[Controller]
public class HomeController : Controller
{
    // GET
    // public IActionResult Index(int id)
    // {
    //     return View();
    // }
    
    public string Index()
    {
        return "Hello World";
    }

    public string OsVersion()
    {
        return Environment.OSVersion.ToString();
    }
}