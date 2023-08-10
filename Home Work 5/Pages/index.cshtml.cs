using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_5.Pages;

public class index : PageModel
{
    public IActionResult OnGetByID(int id)
    {
        Console.WriteLine($"СРАБОТАл {id}");
        return RedirectToPage("book", new { ID = id });
        // return LocalRedirect($"/book?id={id}");
    }
}