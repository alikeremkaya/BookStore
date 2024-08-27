using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HS14_MVCKitapEvi.UI.Controllers
{
    public class BaseController : Controller
    {
        protected INotyfService notyfService => HttpContext.RequestServices.GetService(typeof(INotyfService)) as INotyfService;

        protected void NotifySuccess(string message)
        {
            notyfService.Success(message);
        }
        protected void NotifyError(string message)
        {
            notyfService.Error(message);
        }
    }
}
