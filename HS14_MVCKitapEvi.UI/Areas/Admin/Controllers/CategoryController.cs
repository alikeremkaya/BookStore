using HS14_MVCKitapEvi.Aplication.DTOs.CategoryDTOs;
using HS14_MVCKitapEvi.Aplication.Services.CategoryServices;
using HS14_MVCKitapEvi.Domain.Entities;
using HS14_MVCKitapEvi.Domain.Utilities.Concretes;
using HS14_MVCKitapEvi.UI.Areas.Admin.Models.CategoryVMs;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Localization;

namespace HS14_MVCKitapEvi.UI.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IStringLocalizer<ModelResource> _stringLocalizer;

        public CategoryController(ICategoryService categoryService, IStringLocalizer<ModelResource> stringLocalizer)

        {
            _categoryService = categoryService;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllAsync();
            if (!result.IsSuccess)
            {
                NotifyError(result.Messages);
                return View();
            }
            NotifySuccess(_stringLocalizer["Success"]);

            var categoryListVMs = result.Data.Adapt<List<CategoryListVm>>();

            return View(categoryListVMs);

        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminCategoryCreateVM model)
        {
            var categoryDTO = model.Adapt<CategoryCreateDTO>();
            var result = await _categoryService.CreateAsync(categoryDTO);
            if (!result.IsSuccess)
            {
                notyfService.Error(result.Messages);

                return View(model);
            }
            NotifySuccess(result.Messages);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                NotifyError(result.Messages);

            }
            NotifySuccess(result.Messages);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {

            var category = await _categoryService.GetByIdAsync(id);
            var categoryToUpdate = category.Adapt<AdminCategoryUpdateVm>();
            return View(categoryToUpdate);


        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminCategoryUpdateVm model)
        {
            var result = await _categoryService.UpdateAsync(model.Adapt<CategoryUpdateDTO>());

            if (!result.IsSuccess)
            {
                await Console.Out.WriteLineAsync(result.Messages);

                return RedirectToAction("Index");
            }
            NotifySuccess(result.Messages);


            return RedirectToAction("Index");

        }
    }
}
