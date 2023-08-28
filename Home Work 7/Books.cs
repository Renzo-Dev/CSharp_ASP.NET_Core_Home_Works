namespace Home_Work_7;

public class Book
{
    private static int _bookCounter;

    public Book()
    {
    }

    public Book(string Author, string Genre, int PublicationYear, string Publisher, string Title)
    {
        id = _bookCounter;
        this.Author = Author;
        this.Genre = Genre;
        this.PublicationYear = PublicationYear;
        this.Publisher = Publisher;
        this.Title = Title;
        _bookCounter++;
    }

    public int id { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int PublicationYear { get; set; }
    public string Publisher { get; set; }
    public string Title { get; set; }
}

public static class Books
{
    public static List<Book?> books = new()
    {
        new Book("Леся Українка", "Поезія", 1907, "Київ",
            "Лісова пісня"),
        new Book("Іван Франко", "Роман", 1895, "Львів",
            "Захар Беркут"),
        new Book("Михайло Коцюбинський", "Повість", 1906, "Львів",
            "Тіні забутих предків"),
        new Book(Title: "Война и мир", Author: "Лев Толстой", Genre: "Роман", Publisher: "Русский вестник",
            PublicationYear: 1869),
        new Book(Title: "Гарри Поттер и философский камень", Author: "Джоан Роулинг", Genre: "Фэнтези",
            Publisher: "Розенталь", PublicationYear: 1997),
        new Book(Title: "Преступление и наказание", Author: "Фёдор Достоевский", Genre: "Роман",
            Publisher: "Петербургские ведомости", PublicationYear: 1866),
        new Book(Title: "Мастер и Маргарита", Author: "Михаил Булгаков", Genre: "Сатира", Publisher: "Москва",
            PublicationYear: 1967),
        new Book("George Orwell", "Dystopian Fiction", 1949,
            "Secker & Warburg", "Nineteen Eighty-Four"),
        new Book("J.K. Rowling", "Fantasy", 1997, "Bloomsbury",
            "Harry Potter and the Philosopher's Stone"),
        new Book("Jane Austen", "Classic Fiction", 1813, "Thomas Egerton",
            "Pride and Prejudice"),
        new Book("J.R.R. Tolkien", "Fantasy", 1954, "Allen & Unwin",
            "The Lord of the Rings"),
        new Book("Harper Lee", "Coming-of-age", 1960,
            "J. B. Lippincott & Co.", "To Kill a Mockingbird")
    };
}