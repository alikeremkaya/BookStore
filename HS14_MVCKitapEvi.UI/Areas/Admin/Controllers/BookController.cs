using HS14_MVCKitapEvi.Aplication.DTOs.BookDTOs;
using HS14_MVCKitapEvi.Aplication.DTOs.CategoryDTOs;
using HS14_MVCKitapEvi.Aplication.Services.AuthorService;
using HS14_MVCKitapEvi.Aplication.Services.BookServices;
using HS14_MVCKitapEvi.Aplication.Services.CategoryServices;
using HS14_MVCKitapEvi.Aplication.Services.PublisherServices;
using HS14_MVCKitapEvi.UI.Areas.Admin.Models.BookVMs;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace HS14_MVCKitapEvi.UI.Areas.Admin.Controllers
{
    public class BookController : AdminBaseController
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;

        public BookController(IAuthorService authorService, IBookService bookService, ICategoryService categoryService, IPublisherService publisherService)
        {
            _authorService = authorService;
            _bookService = bookService;
            _categoryService = categoryService;
            _publisherService = publisherService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _bookService.GetAllAsync();
            if (!result.IsSuccess)
            {
                NotifyError(result.Messages);

            }
            var bookListVM = result.Data.Adapt<List<AdminBookListVM>>();
            NotifySuccess(result.Messages);
            return View(bookListVM);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var bookCreateVM = new AdminBookCreateVM();
            bookCreateVM.Authors = await GetAuthors();
            bookCreateVM.Publishers = await GetPublishers();
            bookCreateVM.Categories = await GetCategories();
            return View(bookCreateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminBookCreateVM model)
        {
            var result = await _bookService.CreateAsync(model.Adapt<BookCreateDTO>());
            if (!result.IsSuccess)
            {
                NotifyError(result.Messages);

                return View(model);
            }
            NotifySuccess(result.Messages);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var result = await _bookService.DeleteAsync(Id);

            if (!result.IsSuccess)
            {
                await Console.Out.WriteLineAsync(result.Messages);
                return View();
            }
            await Console.Out.WriteLineAsync(result.Messages);
            NotifySuccess(result.Messages);
            return RedirectToAction("Index");
        }
        public async Task<SelectList>GetBooks(Guid? authorId=null)
        {
            var authors = (await _authorService.GetAllAsync()).Data;
            return new SelectList(authors.Select(x =>new SelectListItem
            {
                Value=x.Id.ToString(),
                Text=x.Name ,
                Selected=x.Id==(authorId != null ? authorId.Value: authorId)
            }).OrderBy(x=> x.Text),"Value","Text");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _bookService.GetByIdAsync(id);
            var bookToUpdate= result.Data.Adapt<AdminBookUpdateVM>();

            bookToUpdate.Authors = await GetAuthors();
            bookToUpdate.Publishers = await GetPublishers();
            bookToUpdate.Categories = await GetCategories();

            
            return View(bookToUpdate);


        }
        [HttpPost]
        public async Task<IActionResult> Update(AdminBookUpdateVM model)
        {
            var result = await _bookService.UpdateAsync(model.Adapt<BookUpdateDTO>());

            if (!result.IsSuccess)
            {
                await Console.Out.WriteLineAsync(result.Messages);
                return RedirectToAction("Index");
            }
            NotifySuccess(result.Messages);


            return RedirectToAction("Index");

        }

        private async Task<SelectList> GetCategories(Guid? categoryId = null)
        {
            var categories = (await _categoryService.GetAllAsync()).Data;
            return new SelectList(categories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == (categoryId != null ? categoryId.Value : categoryId)
            }).OrderBy(x => x.Text), "Value", "Text");
        }

        private async Task<SelectList> GetPublishers(Guid? publisherId = null)
        {
            var publishers = (await _publisherService.GetAllAsync()).Data;
            return new SelectList(publishers.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == (publisherId != null ? publisherId.Value : publisherId)
            }).OrderBy(x => x.Text), "Value", "Text");
        }

        private async Task<SelectList> GetAuthors(Guid? authorId = null)
        {
            var authors = (await _authorService.GetAllAsync()).Data;
            return new SelectList(authors.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == (authorId != null ? authorId.Value : authorId)

            }).OrderBy(x => x.Text), "Value", "Text");
        }
    }
}
