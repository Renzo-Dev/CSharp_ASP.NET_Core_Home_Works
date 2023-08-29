using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_1.Pages
{
    public class Task_3Model : PageModel
    {
        public DateTime _dateTime = DateTime.Now;
        public void OnGet()
        {
        }
    }
}
