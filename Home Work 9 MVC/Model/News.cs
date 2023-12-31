namespace Home_Work_8_MVC.Model;

public class News
{
    public static List<NewsItems> _news = new()
    {
        new NewsItems
        {
            date = "5 августа 2023",
            News_Name = "Новый игровой режим 'Турбо-Раунд' добавлен в CS:GO!",
            content = "Внимание, игроки CS:GO! Valve объявила о добавлении захватывающего нового игрового режима " +
                      "'Турбо-Раунд'. В этом режиме, игроки будут соревноваться в коротких и интенсивных матчах, " +
                      "где раунды сокращены до минимума. Вместо обычных 30 секунд на закупку, в 'Турбо-Раунде' у вас будет " +
                      "всего 10 секунд, чтобы выбрать оружие перед началом раунда. Быстрые реакции и стратегическое мышление" +
                      " станут ключом к победе в этом адреналиновом испытании. Приготовьтесь к быстрому веселью и динамичным " +
                      "баталиям в новом игровом режиме 'Турбо-Раунд'!"
        },
        new NewsItems
        {
            date = "20 Мая 2023",
            News_Name = "Гранд-финал",
            content = "На BLAST.tv Paris Major из 24 команд осталось 2 финалиста: GamerLegion и Team Vitality." +
                      "На этапе чемпионов GamerLegion победили Monte со счётом 2:0, а Heroic — со счётом 2:1, тем самым обеспечив себе место в финале." +
                      "А Team Vitality два раза подряд выиграли перед домашней аудиторией со счётом 2:0, сразив Into the Breach и Apeks. Гранд-финал последнего мейджора по CS:GO состоится завтра, 21 мая, на «Аккор Арене» в Париже." +
                      "Удачи финалистам!"
        },
        new NewsItems
        {
            date = "25 Апреля 2023",
            News_Name = "Коллекция Anubis",
            content = "Ещё с ноября игроки украдкой выглядывали в центр и шли напролом через воды на карте Anubis." +
                      "Сегодня мы представляем коллекцию Anubis, в которую входят 19 тематических раскрасок оружия для карты, недавно пополнившей список передовой." +
                      "Коллекцию Anubis уже можно купить во внутриигровом магазине."
        }
    };
}

public class NewsItems
{
    public string date { get; set; }
    public string News_Name { get; set; }
    public string content { get; set; }
}