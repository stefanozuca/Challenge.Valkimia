using Challenge.Valkimia.Application.DTOs;
using Challenge.Valkimia.Application;
using Challenge.Valkimia.Common;
using Challenge.Valkimia.Presentation.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Challenge.Valkimia.Presentation.Web.Controllers
{
    [Route("Auth")]
    public class AuthController : BaseController
    {
        private readonly IUserAuthenticationService _userAuthenticationService;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public AuthController(
            IMapper mapper,
            IUserAuthenticationService userAuthenticationService,
            INotificationService notificationService) : base(notificationService) {
            _mapper = mapper;
            _userAuthenticationService = userAuthenticationService;
            _notificationService = notificationService;
        }

        /// <summary>
        /// Returns the login view
        /// </summary>
        /// <returns></returns>
        [Route("Login")]
        public IActionResult Login() {
            return View();
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel) {
            if (!ModelState.IsValid)
                return View();

            Result<string> result = await _userAuthenticationService.Login(_mapper.Map<LoginRequestDTO>(loginModel));

            if (result.Succeeded) {
                return RedirectToAction("Index", "Home");
            }
            else {
                ModelState.AddModelError("", "Login failed.  Por favor revise sus credenciales.");
            }

            return View();
        }

        /// <summary>
        /// Logout user
        /// </summary>
        /// <returns></returns>
        [Route("Logout")]
        //[HttpPost]
        public async Task<IActionResult> Logout()
        {
            if (!ModelState.IsValid)
                return View();

            await _userAuthenticationService.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}
