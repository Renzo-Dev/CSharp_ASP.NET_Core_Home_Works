namespace Home_Work_7;

public class Books
{
    public static List<Book> books = new()
    {
        new Book
        {
            Title = "Кобзар",
            AuthorFullName = "Тарас Шевченко",
            Style = "Поэзия",
            Publisher = "Издательство",
            YearOfPublication = "1840"
        },
        new Book
        {
            Title = "Лісова пісня",
            AuthorFullName = "Леся Українка",
            Style = "Поэзия",
            Publisher = "Издательство",
            YearOfPublication = "1911"
        },
        new Book
        {
            Title = "Зів’яле листя",
            AuthorFullName = "Іван Франко",
            Style = "Поэзия",
            Publisher = "Издательство",
            YearOfPublication = "1891"
        },
        new Book
        {
            Title = "Тигролови",
            AuthorFullName = "Іван Багряний",
            Style = "Психологічний роман",
            Publisher = "Клуб сімейного дозвілля",
            YearOfPublication = "1936"
        },
        new Book
        {
            Title = "Заповіт",
            AuthorFullName = "Тарас Шевченко",
            Style = "Літературний романтизм",
            Publisher = "Петербургська аптека",
            YearOfPublication = "1845"
        },
        new Book
        {
            Title = "Гамалія",
            AuthorFullName = "Леся Українка",
            Style = "Символізм",
            Publisher = "Київ",
            YearOfPublication = "1905"
        },
        new Book
        {
            Title = "Война и мир",
            AuthorFullName = "Лев Толстой",
            Style = "Роман",
            Publisher = "Русский вестник",
            YearOfPublication = "1869"
        },
        new Book
        {
            Title = "Преступление и наказание",
            AuthorFullName = "Фёдор Достоевский",
            Style = "Роман",
            Publisher = "Русский вестник",
            YearOfPublication = "1866"
        },
        new Book
        {
            Title = "Мастер и Маргарита",
            AuthorFullName = "Михаил Булгаков",
            Style = "Роман",
            Publisher = "Издательство Художественной литературы",
            YearOfPublication = "1967"
        }
    };
}

public struct Book
{
    public string Title;
    public string AuthorFullName;
    public string Style;
    public string Publisher;
    public string YearOfPublication;
}