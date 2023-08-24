using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_5.Pages;

[IgnoreAntiforgeryToken]
public class bookPage : PageModel
{
    [BindProperty(SupportsGet = true)] public int id { get; set; } = 0;
}