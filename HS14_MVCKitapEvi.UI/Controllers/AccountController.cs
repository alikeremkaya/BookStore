using HS14_MVCKitapEvi.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HS14_MVCKitapEvi.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

      
        public async Task<IActionResult>Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Login(LoginVm model)
        {
            var user =await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                await Console.Out.WriteLineAsync("Email veya şifre hatalı!!");
                return View(model);
            }
            var checkPass=await _signInManager.PasswordSignInAsync(user,model.Password,false,false );
            if (!checkPass.Succeeded)
            {
                await Console.Out.WriteLineAsync("Email veya şifre hatalı!!");
                return View(model);
            }
            var userRole=await _userManager.GetRolesAsync(user);
            if (userRole==null)
            {
                await Console.Out.WriteLineAsync("Email veya şifre hatalı!!!");
                return View(model);

            }
            return RedirectToAction("Index","Home", new{ Area = userRole[0].ToString() });
        }
   
        public async Task <IActionResult>Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");   
        }
    }
}
