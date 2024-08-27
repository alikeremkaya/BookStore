using HS14_MVCKitapEvi.Aplication.DTOs.AuthorDTOs;
using HS14_MVCKitapEvi.Aplication.DTOs.PublisherDTOs;
using HS14_MVCKitapEvi.Aplication.Services.PublisherServices;
using HS14_MVCKitapEvi.UI.Areas.Admin.Models.AuthorVMs;
using HS14_MVCKitapEvi.UI.Areas.Admin.Models.PublisherVMs;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HS14_MVCKitapEvi.UI.Areas.Admin.Controllers
{
    public class PublisherController : AdminBaseController
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        public async Task <IActionResult> Index()
        {
            var result = await _publisherService.GetAllAsync();
            if (!result.IsSuccess)
            {
                await Console.Out.WriteLineAsync(result.Messages);
                return View();

            }
            var publisherListVM = result.Data.Adapt<List<PublisherListVM>>();

            await Console.Out.WriteLineAsync(result.Messages);

            return View(publisherListVM);


        }
        public async Task <IActionResult> Create()
        {
            return  View();  
        }
        [HttpPost]  
        public async Task<IActionResult>Create(AdminPublisherCreateVM model)
        {
            var publisherCreateDTO= model.Adapt<PublisherCreateDTO>();
            var result = await _publisherService.CreateAsync(publisherCreateDTO);

            if (!result.IsSuccess)
            {
                await Console.Out.WriteLineAsync($"{result.Messages}");
            }
            await Console.Out.WriteLineAsync($"{result.Messages}");
            return RedirectToAction("Index");


        }
        public async Task <IActionResult>Delete(Guid Id)
        {
            var result = await _publisherService.DeleteAsync(Id);

            if (!result.IsSuccess)
            {
                await Console.Out.WriteLineAsync(result.Messages);
                return View();
            }
            await Console.Out.WriteLineAsync(result.Messages);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _publisherService.GetByIdAsync(id);
            var publisherUpdateVm = result.Data.Adapt<AdminPublisherUpdateVM>();
            return View(publisherUpdateVm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminPublisherUpdateVM model)
        {
            var publisherDTO = model.Adapt<PublisherUpdateDTO>();
            var result = await _publisherService.UpdateAsync(publisherDTO);
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
