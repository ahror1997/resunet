using NpgsqlTypes;
using Resunet.DAL.Models;

namespace Resunet.BL.Auth
{
	public interface IAuthBL
	{
		Task<int> CreateUser(UserModel model);
		Task<int> Authenticate(string email, string password, bool rememberMe);
	}
}
