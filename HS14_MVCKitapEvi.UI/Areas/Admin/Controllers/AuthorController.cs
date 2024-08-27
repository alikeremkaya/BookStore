using HS14_MVCKitapEvi.Aplication.DTOs.AuthorDTOs;
using HS14_MVCKitapEvi.Aplication.Services.AuthorService;
using HS14_MVCKitapEvi.UI.Areas.Admin.Models.AuthorVMs;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HS14_MVCKitapEvi.UI.Areas.Admin.Controllers
{
    public class AuthorController : AdminBaseController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _authorService.GetAllAsync();

            if (!result.IsSuccess)
            {
                NotifyError(result.Messages);
                return View();
            }
            var authorListVM= result.Data.Adapt<List<AuthorListVM>>();
            NotifySuccess(result.Messages);
            return View(authorListVM);
            
        }
        public async Task <IActionResult>Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult>Create(AdminAuthorCreateVM model)
        {
            var authorDTO = model.Adapt<AuthorCreateDTO>(); 
            var result= await _authorService.CreateAsync(authorDTO);
            if (!result.IsSuccess)
            {
                await Console.Out.WriteLineAsync($"{result.Messages}"); 
            }
            await Console.Out.WriteLineAsync(result.Messages);
            return RedirectToAction("Index"); 
        }
        public async Task<IActionResult>Delete(Guid Id)
        {
            var result = await _authorService.DeleteAsync(Id);

            if (!result.IsSuccess)
            {
                await Console.Out.WriteLineAsync(result.Messages);
                return View();
            }

            await Console.Out.WriteLineAsync(result.Messages);

            return RedirectToAction("Index");
             
        }
        public async Task<IActionResult>Update(Guid id)
        {
            var result =await _authorService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                await Console.Out.WriteLineAsync(result.Messages);
                return View();
            }
            var authorVM= result.Data.Adapt<AdminAuthorUpdateVM>();
            await Console.Out.WriteLineAsync(result.Messages);
            return View(authorVM);
        }
        [HttpPost]  
        public async Task <IActionResult>Update(AdminAuthorUpdateVM model)
        {
            var authorDTO = model.Adapt<AuthorUpdateDTO>();
            var result = await _authorService.UpdateAsync(authorDTO);
            if (!result.IsSuccess)
            {
                await Console.Out.WriteLineAsync(result.Messages);
                return View(model);
            }
            await Console.Out.WriteLineAsync(result.Messages);
            return RedirectToAction("Index");
        }
           

    }
}
