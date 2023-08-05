using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_4.Pages;

public class News : PageModel
{
    public List<NewsItems> _news = new()
    {
        new()
        {
            date = "5 августа 2023",
            News_Name = "Новый игровой режим 'Турбо-Раунд' добавлен в CS:GO!",
            content = "Внимание, игроки CS:GO! Valve объявила о добавлении захватывающего нового игрового режима " +
                      "'Турбо-Раунд'. В этом режиме, игроки будут соревноваться в коротких и интенсивных матчах, " +
                      "где раунды сокращены до минимума. Вместо обычных 30 секунд на закупку, в 'Турбо-Раунде' у вас будет " +
                      "всего 10 секунд, чтобы выбрать оружие перед началом раунда. Быстрые реакции и стратегическое мышление" +
                      " станут ключом к победе в этом адреналиновом испытании. Приготовьтесь к быстрому веселью и динамичным " +
                      "баталиям в новом игровом режиме 'Турбо-Раунд'!"
        }
    };

    public void OnGet()
    {
    }
}

public class NewsItems
{
    public string date { get; set; }
    public string News_Name { get; set; }
    public string content { get; set; }
}