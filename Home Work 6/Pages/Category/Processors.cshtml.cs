using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_6.Pages.Category;

public class Processors : PageModel
{
    public ProcessorStruct ProcessorStruct = new();

    public void OnGet()
    {
    }
}