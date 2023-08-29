using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Home_Work_1.Pages
{
    public class Task_4Model : PageModel
    {
        // requires using Microsoft.Extensions.Configuration;
        private readonly IConfiguration _configuration;

        // ВОТ ТУТ НЕ РАБОТАЕТ , ПИШЕТ ЧТО "Метод должен возвращать значение"
        public Task_4Model(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? MyName { get; set; }
        public string? MyTitle { get; set; }
        public string? MyAge { get; set; }

        public void OnGet()
        {
            var name = _configuration["Position:Name"];
            var title = _configuration["Position:Title"];
            var age = _configuration["Position:Age"];

            MyName = $"My Name: {name}";
            MyTitle = $"Title: {title}";
            MyAge = $"My YO: {age}";
        }
    }
}