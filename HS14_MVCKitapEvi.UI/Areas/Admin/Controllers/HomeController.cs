using Microsoft.AspNetCore.Mvc;

namespace HS14_MVCKitapEvi.UI.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
