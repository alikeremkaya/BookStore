using Microsoft.AspNetCore.Mvc;

namespace HS14_MVCKitapEvi.UI.Areas.ProfileUser.Controllers;

public class HomeController : ProfileUserBaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
