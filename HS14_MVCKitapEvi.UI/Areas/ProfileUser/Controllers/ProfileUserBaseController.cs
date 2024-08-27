using HS14_MVCKitapEvi.UI.Areas.Admin.Controllers;
using HS14_MVCKitapEvi.UI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HS14_MVCKitapEvi.UI.Areas.ProfileUser.Controllers
{
    [Area("ProfileUser")]
    [Authorize(Roles = "ProfileUser")]

    public class ProfileUserBaseController : BaseController
    {
        
        
    }
}
