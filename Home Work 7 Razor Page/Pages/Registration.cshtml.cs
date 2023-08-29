using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_7.Pages;

public class Registration : PageModel
{
    [BindProperty] public User user { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid) Users._users.Add(user);
        // или сделать страницу ЧТО ВЫ ЗАРЕГИСТРИРОВАНЫ)
        return Page();
    }
}