using NpgsqlTypes;
using Resunet.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Resunet.BL.Auth
{
	public interface IAuthBL
	{
		Task<int> CreateUser(UserModel model);
		Task<int> Authenticate(string email, string password, bool rememberMe);
		Task<ValidationResult?> ValidateEmail(string email); 
	}
}
