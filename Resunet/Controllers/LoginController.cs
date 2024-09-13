using Microsoft.AspNetCore.Mvc;
using Resunet.BL.Auth;
using Resunet.ViewModels;

namespace Resunet.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthBL authBL;

        public LoginController(IAuthBL authBL)
        {
            this.authBL = authBL;
        }

        [HttpGet]
        [Route("/login")]
        public IActionResult Index()
        {
            return View("Index", new LoginViewModel());
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> IndexSave(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await authBL.Authenticate(model.Email!, model.Password!, model.RememberMe);
                    return Redirect("/");
                }
                catch (BL.Exceptions.AuthorizationException)
                {
                    ModelState.AddModelError("Email", "Email или Пароль неверные");
                }
            }

            return View("Index", model);
        }
    }
}
