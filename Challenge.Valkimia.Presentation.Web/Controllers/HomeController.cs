using Challenge.Valkimia.Application;
using Challenge.Valkimia.Presentation.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Valkimia.Presentation.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index() {
            var model = new HomeViewModel();
          
            return View(model);
        }

    }
}