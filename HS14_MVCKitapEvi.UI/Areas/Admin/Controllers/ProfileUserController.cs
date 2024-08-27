using HS14_MVCKitapEvi.Aplication.DTOs.ProfileUserDTOs;
using HS14_MVCKitapEvi.Aplication.Services.ProfileUserServices;
using HS14_MVCKitapEvi.Domain.Utilities.Concretes;
using HS14_MVCKitapEvi.UI.Areas.Admin.Models.ProfileUserVMs;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HS14_MVCKitapEvi.UI.Areas.Admin.Controllers
{
    public class ProfileUserController : AdminBaseController
    {
        private readonly IProfileUserService _profileUserService;

        public ProfileUserController(IProfileUserService profileUserService)
        {
            _profileUserService = profileUserService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _profileUserService.GetAllAsync();
            var profileUserVMs = result.Data.Adapt<List<ProfileUserListVM>>();
            if (!result.IsSuccess)
            {
                NotifyError(result.Messages);
                return View(profileUserVMs);


            }
            NotifySuccess(result.Messages);

            return View(profileUserVMs);
        }
        public async Task<IActionResult> Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(ProfileUserCreateVM model)
        {
            var result = await _profileUserService.CreateAsync(model.Adapt<ProfileUserCreateDTO>());
            if (!result.IsSuccess)
            {
                NotifyError(result.Messages);
                return View(model);
            }
            NotifySuccess(result.Messages);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Guid id)
        {



            var result = await _profileUserService.DeleteAsync(id);

            if (!result.IsSuccess)
            {
                NotifyError(result.Messages);
                return View();
            }

            NotifySuccess(result.Messages);
            return RedirectToAction("Index");

        }

        public async Task <IActionResult> Update(Guid id)
        {
            var result=  await _profileUserService.GetByIdAsync(id);

            var profileUserUpdateVM = result.Data.Adapt<ProfileUserUpdateVM>();

            return View(profileUserUpdateVM);
        }


        [HttpPost]
        public async Task<IActionResult> Update(ProfileUserUpdateVM updateProfileUserVM)

        {
           var updateProfileUserDTO= updateProfileUserVM.Adapt<ProfileUserUpdateDTO>();
            var result=await _profileUserService.UpdateAsync(updateProfileUserDTO);
            if (!result.IsSuccess)
            {
                await Console.Out.WriteLineAsync(result.Messages);
                return View(updateProfileUserVM);
            }
            await Console.Out.WriteLineAsync(result.Messages);
            return RedirectToAction("Index");

        }
    }
}
