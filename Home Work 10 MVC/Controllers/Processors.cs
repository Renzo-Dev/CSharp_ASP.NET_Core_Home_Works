using Home_Work_6;
using Microsoft.AspNetCore.Mvc;

namespace Home_Work_10_MVC.Controllers;

public class Processors : Controller
{
    public static Processor? Processor;

    // GET
    [HttpGet]
    public IActionResult ProcessorsResult()
    {
        return View("~/Views/Category/Processors.cshtml");
    }

    public IActionResult ProcessorDetails(string name)
    {
        var processors = new ProcessorStruct();
        Processor = new Processor(processors.GetProcessorDetails(name));
        return View("~/Views/Category/ProcessorDetails.cshtml");
    }
}