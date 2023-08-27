using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_7.Pages;

public class BookManagement : PageModel
{
    public void OnGet()
    {

    }

    public void OnGetDelete(string bookName = "")
    {
        if (bookName.Length <= 0) return;
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