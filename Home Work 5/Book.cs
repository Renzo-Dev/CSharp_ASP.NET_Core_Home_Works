namespace Home_Work_5;

public class Book
{
    public static List<Book> books = new()
    {
        new()
        {
            Title = "Преступление и наказание",
            Author = "Фёдор Достоевский",
            Genre = "Роман",
            Publisher = "The Russian Messenger",
            PublicationYear = 1866
        },
        new()
        {
            Title = "1984",
            Author = "Джордж Оруэлл",
            Genre = "Дистопия",
            Publisher = "Secker & Warburg",
            PublicationYear = 1949
        },
        new()
        {
            Title = "Война и мир",
            Author = "Лев Толстой",
            Genre = "Роман",
            Publisher = "Русский вестник",
            PublicationYear = 1869
        },
        new()
        {
            Title = "1984",
            Author = "Джордж Оруэлл",
            Genre = "Научная фантастика",
            Publisher = "Северный альянс",
            PublicationYear = 1949
        },
        new()
        {
            Title = "Гарри Поттер и философский камень",
            Author = "Джоан Роулинг",
            Genre = "Фэнтези",
            Publisher = "Розенталь",
            PublicationYear = 1997
        },
        new()
        {
            Title = "Преступление и наказание",
            Author = "Фёдор Достоевский",
            Genre = "Роман",
            Publisher = "Петербургские ведомости",
            PublicationYear = 1866
        },
        new()
        {
            Title = "1984",
            Author = "Джордж Оруэлл",
            Genre = "Фантастика",
            Publisher = "Северное море",
            PublicationYear = 1949
        },
        new()
        {
            Title = "Мастер и Маргарита",
            Author = "Михаил Булгаков",
            Genre = "Сатира",
            Publisher = "Москва",
            PublicationYear = 1967
        }
    };

    public string Author;
    public string Genre;
    public int PublicationYear;
    public string Publisher;

    public string Title;
}