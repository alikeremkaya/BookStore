using HS14_MVCKitapEvi.Aplication.DTOs.AdminDTOs;
using HS14_MVCKitapEvi.Aplication.Services.AdminService;
using HS14_MVCKitapEvi.UI.Areas.Admin.Models.AdminVMs;
using HS14_MVCKitapEvi.UI.Areas.Admin.Models.AuthorVMs;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HS14_MVCKitapEvi.UI.Areas.Admin.Controllers
{
    public class AdminController : AdminBaseController
    {



        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task <IActionResult> Index()
        { 
            var result = await _adminService.GetAllAsync();
            var adminListVM = result.Data.Adapt<List<AdminListVM>>();
            if (!result.IsSuccess)
            {
                NotifyError(result.Messages);
                return View();
            }
          
            NotifySuccess(result.Messages);

            return View(adminListVM);

        }
        [HttpGet]
        public async Task <IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(AdminCreateVM adminModel)
        {
            var adminDTO = adminModel.Adapt<AdminCreateDTO>();
            var result = await _adminService.CreateAsync(adminDTO);
            if (!result.IsSuccess)
            {

                NotifyError(result.Messages);
                return View(adminModel);
            }
            NotifySuccess(result.Messages);

            return RedirectToAction("Index");


        }
        public async Task<IActionResult>Delete(Guid id)
        {
            var result= await _adminService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                NotifyError(result.Messages);
                return View(result);    
            }
            
            NotifySuccess(result.Messages);
            return RedirectToAction("Index");

        }


        public async Task <IActionResult> Update(Guid id)
        {
            var result =await _adminService.GetByIdAsync(id);
            var adminUpdateVM= result.Data.Adapt<AdminUpdateVM>();
            return View(adminUpdateVM);

        }

        [HttpPost]
        public async Task <IActionResult> Update(AdminUpdateVM adminUpdateVM)
        {
            var updateAdminDTO= adminUpdateVM.Adapt<AdminUpdateDTO>();  
            var result = await _adminService.UpdateAsync(updateAdminDTO);
            if (!result.IsSuccess)
            {

                NotifyError(result.Messages);
                return View(adminUpdateVM);

            }
            NotifySuccess(result.Messages);
            return RedirectToAction("Index");
        }





    }
}
