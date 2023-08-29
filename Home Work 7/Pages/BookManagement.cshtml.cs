using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Home_Work_7.Pages
{
    [IgnoreAntiforgeryToken]
    public class BookManagement : PageModel
    {
        public IActionResult OnGetBook(int id = 0)
        {
            var sendBook = Books.books.Find(book => book != null && book.id == id);
            if (sendBook != null)
            {
                var data = new
                {
                    Id = sendBook.id,
                    title = sendBook.Title,
                    publicationYear = sendBook.PublicationYear,
                    publisher = sendBook.Publisher,
                    author = sendBook.Author,
                    genre = sendBook.Genre
                };
                return new JsonResult(data);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        public async Task<IActionResult> OnPostCreate()
        {
            var requestBody = await new StreamReader(Request.Body).ReadToEndAsync();
            var bookData = JsonConvert.DeserializeObject<Book>(requestBody);

            if (bookData != null)
            {
                Books.books.Add(bookData);
                var result = new { Status = "Книга добавлена в библиотеку" };
                return new JsonResult(result);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                var result = new { Status = "Ошибка, не удалось создать книгу" };
                return new JsonResult(result);
            }
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            var requestBody = await new StreamReader(Request.Body).ReadToEndAsync();
            var bookData = JsonConvert.DeserializeObject<Book>(requestBody);

            if (bookData != null)
            {
                var index = Books.books.FindIndex(book => book.id == bookData.id);
                if (index != -1)
                {
                    Books.books[index] = bookData;
                    return RedirectToPage();
                }
                else
                {
                    HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    var result = new { Status = "Ошибка, книга не найдена" };
                    return new JsonResult(result);
                }
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                var result = new { Status = "Ошибка, книга не найдена" };
                return new JsonResult(result);
            }
        }

        public IActionResult OnPostDeleteBook(int id = 0)
        {
            Books.books.RemoveAt(Books.books.FindIndex(book => book.id == id));
            return RedirectToPage();
        }
    }
}
