using HS14_MVCKitapEvi.Aplication.Services.BookServices;
using HS14_MVCKitapEvi.UI.Areas.ProfileUser.Models.BookVM;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HS14_MVCKitapEvi.UI.Areas.ProfileUser.Controllers
{
    public class BookController : ProfileUserBaseController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task <IActionResult> Index()
        {
            var result  =await _bookService.GetAllForProfileUserAsync();

            var bookListVMs= result.Data.Adapt<List<BookListVM>>(); 

            return View(bookListVMs);
        }
    }
}
