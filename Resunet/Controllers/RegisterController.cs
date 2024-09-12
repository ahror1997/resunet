using Microsoft.AspNetCore.Mvc;
using Resunet.BL.Auth;
using Resunet.ViewMapper;
using Resunet.ViewModels;

namespace Resunet.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IAuthBL authBL;

        public RegisterController(IAuthBL authBL)
        {
            this.authBL = authBL;
        }

		[HttpGet]
		[Route("/register")]
        public IActionResult Index()
		{
			return View("Index", new RegisterViewModel());
		}

		[HttpPost]
		[Route("/register")]
		public async Task<IActionResult> IndexSave(RegisterViewModel model)
		{
            if (ModelState.IsValid)
            {
                var errorModel = await authBL.ValidateEmail(model.Email ?? "");
                if (errorModel != null)
                {
                    ModelState.TryAddModelError("Email", errorModel.ErrorMessage!);
                }
            }


            if (ModelState.IsValid)
            {
				await authBL.CreateUser(AuthMapper.RegisterViewModelToUserModel(model));
				return Redirect("/");
            }

            return View("Index", new RegisterViewModel());
		}
	}
}