using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Home_Work_1.Pages
{
    public class Task_4Model : PageModel
    {
        // requires using Microsoft.Extensions.Configuration;
        private readonly IConfiguration Configuration;

        // ВОТ ТУТ НЕ РАБОТАЕТ , ПИШЕТ ЧТО "Метод должен возвращать значение"
        public IndexModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string MyName { get; set; }
        public string MyTitle { get; set; }
        public string MyAge { get; set; }

        public void OnGet()
        {
            var name = Configuration["Position:Name"];
            var title = Configuration["Position:Title"];
            var age = Configuration["Position:Age"];
            
            MyName = $"My Name: {name}";
            MyTitle = $"Title: {title}";
            MyAge = $"My YO: {age}";
        }
    }
}