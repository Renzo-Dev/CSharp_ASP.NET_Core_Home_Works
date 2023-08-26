namespace Home_Work_7;

public class Books
{
    public static List<Books> books = new()
    {
        new Books
        {
            Author = "Леся Українка",
            Genre = "Поезія",
            PublicationYear = 1907,
            Publisher = "Київ",
            Title = "Лісова пісня"
        },
        new Books
        {
            Author = "Іван Франко",
            Genre = "Роман",
            PublicationYear = 1895,
            Publisher = "Львів",
            Title = "Захар Беркут"
        },
        new Books
        {
            Author = "Михайло Коцюбинський",
            Genre = "Повість",
            PublicationYear = 1906,
            Publisher = "Львів",
            Title = "Тіні забутих предків"
        },
        new Books
        {
            Title = "Война и мир",
            Author = "Лев Толстой",
            Genre = "Роман",
            Publisher = "Русский вестник",
            PublicationYear = 1869
        },
        new Books
        {
            Title = "Гарри Поттер и философский камень",
            Author = "Джоан Роулинг",
            Genre = "Фэнтези",
            Publisher = "Розенталь",
            PublicationYear = 1997
        },
        new Books
        {
            Title = "Преступление и наказание",
            Author = "Фёдор Достоевский",
            Genre = "Роман",
            Publisher = "Петербургские ведомости",
            PublicationYear = 1866
        },
        new Books
        {
            Title = "Мастер и Маргарита",
            Author = "Михаил Булгаков",
            Genre = "Сатира",
            Publisher = "Москва",
            PublicationYear = 1967
        },
        new Books
        {
            Author = "George Orwell",
            Genre = "Dystopian Fiction",
            PublicationYear = 1949,
            Publisher = "Secker & Warburg",
            Title = "Nineteen Eighty-Four"
        },
        new Books
        {
            Author = "J.K. Rowling",
            Genre = "Fantasy",
            PublicationYear = 1997,
            Publisher = "Bloomsbury",
            Title = "Harry Potter and the Philosopher's Stone"
        },
        new Books
        {
            Author = "Jane Austen",
            Genre = "Classic Fiction",
            PublicationYear = 1813,
            Publisher = "Thomas Egerton",
            Title = "Pride and Prejudice"
        },
        new Books
        {
            Author = "J.R.R. Tolkien",
            Genre = "Fantasy",
            PublicationYear = 1954,
            Publisher = "Allen & Unwin",
            Title = "The Lord of the Rings"
        },
        new Books
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