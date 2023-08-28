using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Home_Work_7.Pages;

public class BookManagement : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnGetBook(int id = 0)
    {
        var sendBook = Books.books.Find(book => book != null && book.id == id);
        if (sendBook != null)
        {
            var data = new
            {
                Id = sendBook.id, title = sendBook.Title, publicationYear = sendBook.PublicationYear,
                publisher = sendBook.Publisher, author = sendBook.Author, genre = sendBook.Genre
            };
            return new JsonResult(data);
        }

        return StatusCode(StatusCodes.Status404NotFound);
    }

    // TEST
    public async Task<IActionResult> OnPostUpdate()
    {
        Console.WriteLine("WORK");
        var requestBody = await new StreamReader(Request.Body).ReadToEndAsync();
        var receivedData = JsonConvert.DeserializeObject<Book>(requestBody);

        // Обработка receivedData

        var result = new { Status = "Success" }; // Пример результата

        return new JsonResult(result);
    }

    public IActionResult OnPostDeleteBook(int id = 0)
    {
        Books.books.RemoveAt(Books.books.FindIndex(book => book.id == id));
        return RedirectToPage();
    }
}