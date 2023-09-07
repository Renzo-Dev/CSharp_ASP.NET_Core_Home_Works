using Microsoft.AspNetCore.Mvc;

namespace Home_Work_9_MVC.Controlls;

public class PageInfo : Controller
{
    public static string PartialPage { get; set; }

    [HttpGet]
    public IActionResult PageInfoGenerator()
    {
        ViewBag.Title = "Home Page";
        PartialPage = "~/Views/Partials/MainPage.cshtml";
        return View("~/Views/Pages/PageInfoGen.cshtml");
    }

    [HttpGet]
    public IActionResult Python()
    {
        ViewBag.Title = "Python";
        ViewData["NamePage"] = "Python";
        PartialPage = "~/Views/Partials/UniversalPage.cshtml";
        return View("~/Views/Pages/PageInfoGen.cshtml");
    }

    [HttpGet]
    public IActionResult CPlus_Plus()
    {
        ViewBag.Title = "C++";
        ViewData["NamePage"] = "C++";
        PartialPage = "~/Views/Partials/UniversalPage.cshtml";
        return View("~/Views/Pages/PageInfoGen.cshtml");
    }

    [HttpGet]
    public IActionResult CSharp()
    {
        ViewBag.Title = "C#";
        ViewData["NamePage"] = "C#";
        PartialPage = "~/Views/Partials/UniversalPage.cshtml";
        return View("~/Views/Pages/PageInfoGen.cshtml");
    }

    [HttpGet]
    public IActionResult JavaScript()
    {
        ViewBag.Title = "Java Script";
        ViewData["NamePage"] = "Java Script";
        PartialPage = "~/Views/Partials/UniversalPage.cshtml";
        return View("~/Views/Pages/PageInfoGen.cshtml");
    }

    [HttpGet]
    public IActionResult UnrealEngine()
    {
        ViewBag.Title = "Unreal Engine";
        ViewData["NamePage"] = "Unreal Engine";
        PartialPage = "~/Views/Partials/UniversalPage.cshtml";
        return View("~/Views/Pages/PageInfoGen.cshtml");
    }

    [HttpGet]
    public IActionResult Forma()
    {
        ViewBag.Title = "Forma";
        ViewData["NamePage"] = "Forma";
        PartialPage = "~/Views/Partials/Forma.cshtml";
        return View("~/Views/Pages/PageInfoGen.cshtml");
    }

    [HttpPost]
    public IActionResult Forma(string name, string email)
    {
        ViewBag.Message =
            $"<script>alert(`Пользователь {name} с адресом {email}\n успешно зарегистрирован!`);</script>";
        PartialPage = "~/Views/Partials/Forma.cshtml";
        ViewBag.Title = "Forma";
        ViewData["NamePage"] = "Forma";
        return View("~/Views/Pages/PageInfoGen.cshtml");
    }
}