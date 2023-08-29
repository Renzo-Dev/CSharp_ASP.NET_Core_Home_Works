namespace Home_Work_5;

public class Book
{
    public static List<Book> books = new()
    {
        new Book
        {
            Author = "Леся Українка",
            Genre = "Поезія",
            PublicationYear = 1907,
            Publisher = "Київ",
            Title = "Лісова пісня"
        },
        new Book
        {
            Author = "Іван Франко",
            Genre = "Роман",
            PublicationYear = 1895,
            Publisher = "Львів",
            Title = "Захар Беркут"
        },
        new Book
        {
            Author = "Михайло Коцюбинський",
            Genre = "Повість",
            PublicationYear = 1906,
            Publisher = "Львів",
            Title = "Тіні забутих предків"
        },
        new Book
        {
            Title = "Война и мир",
            Author = "Лев Толстой",
            Genre = "Роман",
            Publisher = "Русский вестник",
            PublicationYear = 1869
        },
        new Book
        {
            Title = "Гарри Поттер и философский камень",
            Author = "Джоан Роулинг",
            Genre = "Фэнтези",
            Publisher = "Розенталь",
            PublicationYear = 1997
        },
        new Book
        {
            Title = "Преступление и наказание",
            Author = "Фёдор Достоевский",
            Genre = "Роман",
            Publisher = "Петербургские ведомости",
            PublicationYear = 1866
        },
        new Book
        {
            Title = "Мастер и Маргарита",
            Author = "Михаил Булгаков",
            Genre = "Сатира",
            Publisher = "Москва",
            PublicationYear = 1967
        },
        new Book
        {
            Author = "George Orwell",
            Genre = "Dystopian Fiction",
            PublicationYear = 1949,
            Publisher = "Secker & Warburg",
            Title = "Nineteen Eighty-Four"
        },
        new Book
        {
            Author = "J.K. Rowling",
            Genre = "Fantasy",
            PublicationYear = 1997,
            Publisher = "Bloomsbury",
            Title = "Harry Potter and the Philosopher's Stone"
        },
        new Book
        {
            Author = "Jane Austen",
            Genre = "Classic Fiction",
            PublicationYear = 1813,
            Publisher = "Thomas Egerton",
            Title = "Pride and Prejudice"
        },
        new Book
        {
            Author = "J.R.R. Tolkien",
            Genre = "Fantasy",
            PublicationYear = 1954,
            Publisher = "Allen & Unwin",
            Title = "The Lord of the Rings"
        },
        new Book
        {
            Author = "Harper Lee",
            Genre = "Coming-of-age",
            PublicationYear = 1960,
            Publisher = "J. B. Lippincott & Co.",
            Title = "To Kill a Mockingbird"
        }
    };

    public string Author;
    public string Genre;
    public int PublicationYear;
    public string Publisher;
    public string Title;
}