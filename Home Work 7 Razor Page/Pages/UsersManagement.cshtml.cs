using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Home_Work_7.Pages;

[IgnoreAntiforgeryToken]
public class UsersManagement : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnGetUser(string guid = null)
    {
        var sendUser = Users._users.Find(book => book.guid == guid);
        if (sendUser != null)
        {
            var data = new
            {
                sendUser.guid, sendUser.login, sendUser.password, sendUser.email
            };
            return new JsonResult(data);
        }

        return StatusCode(StatusCodes.Status404NotFound);
    }

    public async Task<IActionResult> OnPostCreate()
    {
        var requestBody = await new StreamReader(Request.Body).ReadToEndAsync();
        var userData = JsonConvert.DeserializeObject<User>(requestBody);

        if (userData != null)
        {
            Users._users.Add(userData);
            var result = new { Status = "Пользователь добавлен" }; // Пример результата
            return new JsonResult(result);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            var result = new { Status = "Ошибка , не удалось создать пользователя" }; // Пример результата
            return new JsonResult(result);
        }
    }

    public async Task<IActionResult> OnPostUpdate()
    {
        var requestBody = await new StreamReader(Request.Body).ReadToEndAsync();
        var userData = JsonConvert.DeserializeObject<User>(requestBody);
        if (userData != null)
        {
            var index = Users._users.FindIndex(user => user.guid == userData.guid);
            if (index != -1)
            {
                Users._users[index] = userData;
                return RedirectToPage();
            }

            HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            var result = new { Status = "Ошибка , пользователь не найдена" }; // Пример результата
            return new JsonResult(result);
        }

        {
            HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            var result = new { Status = "Ошибка , пользователь не найдена" }; // Пример результата
            return new JsonResult(result);
        }
    }

    public IActionResult OnPostDeleteUser(string? guid = null)
    {
        Users._users.RemoveAt(Users._users.FindIndex(User => User.guid == guid));
        return RedirectToPage();
    }
}