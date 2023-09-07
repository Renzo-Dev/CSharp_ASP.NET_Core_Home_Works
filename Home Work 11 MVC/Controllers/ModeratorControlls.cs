using Home_Work_10_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Home_Work_10_MVC.Controllers;

[IgnoreAntiforgeryToken]
public class ModeratorControlls : Controller
{
    public static List<Message> Messages = new()
    {
        new Message("Куртой сайт", "Renzo"),
        new Message("Когда обнова сайт", "Dispace"),
        new Message("Сколько людей на вашем сайте?", "TheDarkReaper"),
        new Message("Как пройти в библиотеку?", "PIPEC"),
        new Message("Как у вас погода?", "Shrud1")
    };

    [HttpGet]
    public IActionResult MessagesForModerator()
    {
        return View("~/Views/Category/MessagesForModerator.cshtml");
    }

    [HttpPost]
    public async void MessagesModerator()
    {
        var reader = new StreamReader(Request.Body);
        var json = await reader.ReadToEndAsync();
        // Закрываем поток
        reader.Close();
        // JSON to Object
        var message = JsonConvert.DeserializeObject<Message>(json);

        if (message != null) Messages.Add(message);
    }
}