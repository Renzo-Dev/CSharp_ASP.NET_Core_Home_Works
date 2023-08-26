using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_7.Pages;

public class Index : PageModel
{
    public int YearFrom;
    public int YearTo = 2023;

    public IActionResult OnGet(int yearFrom = 0, int yearTo = 2023)
    {
        YearFrom = yearFrom;
        YearTo = yearTo;
        return Page();
    }
}