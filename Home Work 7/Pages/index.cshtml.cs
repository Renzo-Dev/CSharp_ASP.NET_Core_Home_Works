using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_7.Pages;

public class Index : PageModel
{
    public int YearFrom = 1500;
    public int YearTo = 2023;

    public void OnGet()
    {
        
    }
    
    public IActionResult  OnGetYear(int yearFrom, int yearTo)
    {
        Console.WriteLine("WORK");
        if (!yearFrom.Equals(YearFrom) )
            YearFrom = yearFrom;
        if (!yearFrom.Equals(YearFrom))
            YearTo = yearTo;
        var jsonData = new { Name = "John", Age = 30 };
        ///////////////////////
        ///////////////////////
        /////////////////////// ОТПРАВЛЯЕМ НОВЫЕ КНИГИ
        ///////////////////////
        ///////////////////////
        ///////////////////////
        return new JsonResult(jsonData);
    }
}