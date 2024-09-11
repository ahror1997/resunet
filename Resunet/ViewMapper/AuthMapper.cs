using Resunet.DAL.Models;
using Resunet.ViewModels;

namespace Resunet.ViewMapper
{
	public class AuthMapper
	{
		public static UserModel RegisterViewModelToUserModel(RegisterViewModel model)
		{
			return new UserModel()
			{
				Email = model.Email ?? "",
				Password = model.Password ?? ""
			};
		}
	}
}
