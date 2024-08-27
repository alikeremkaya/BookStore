using HS14_MVCKitapEvi.Aplication.Services.CategoryServices;
using HS14_MVCKitapEvi.UI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HS14_MVCKitapEvi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminBaseController : BaseController
    {
       


    }
}
