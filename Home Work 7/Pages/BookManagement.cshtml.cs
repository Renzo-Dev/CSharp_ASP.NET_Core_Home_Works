using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_7.Pages;

public class BookManagement : PageModel
{
    public void OnGet()
    {

    }

    public void OnGetDelete(string bookName = "")
    {
        Console.WriteLine("WORK");
        if (bookName.Length > 0)
        {
            for (int i = 0; i < Books.books.Count; i++)
            {
                Console.WriteLine(i);
                if (string.Equals(Books.books[i].Title, bookName, StringComparison.CurrentCultureIgnoreCase))
                {
                    Books.books.RemoveAt(i);
                    break;
                }
            }
        }
    }
}