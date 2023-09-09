using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_1.Pages;

public class Task_5Model : PageModel
{
    public string Author { get; set; }
    public string Citation { get; set; }

    public void OnGet()
    {
        var citations = new List<Citations>();
        citations?.Add(new Citations("Альберт Эйнштейн", "Чем умнее человек, тем легче он признает себя дураком"));
        citations?.Add(new Citations("Теодор Рузвельт", "Никогда не ошибается тот, кто ничего не делает"));
        citations?.Add(new Citations("Лев Николаевич Толстой", "Менее всего просты люди, желающие казаться простыми"));
        citations?.Add(new Citations(" Мартин Лютер Кинг",
            "Если человек не нашёл, за что может умереть, он не способен жить"));

        if (Request.Path == "/Task 5")
        {
            var randomId = new Random().Next(citations.Count);
            Author = citations[randomId].Author;
            Citation = citations[randomId].citation;
        }
    }

    private struct Citations
    {
        public readonly string Author;
        public readonly string citation;

        public Citations(string author, string citation)
        {
            Author = author;
            this.citation = citation;
        }
    }
}