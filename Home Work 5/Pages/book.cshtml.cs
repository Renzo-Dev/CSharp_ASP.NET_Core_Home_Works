using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_5.Pages;

public class book : PageModel
{
    public int _id;

    public IActionResult OnGet(int id = -1)
    {
        Console.WriteLine($"Получили BOOK {id}");
        _id = id;
        return Page();
    }
}