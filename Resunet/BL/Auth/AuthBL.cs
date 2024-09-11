using Resunet.DAL;
using Resunet.DAL.Models;

namespace Resunet.BL.Auth
{
	public class AuthBL : IAuthBL
	{
		private readonly IAuthDAL authDAL;

        public AuthBL(IAuthDAL authDAL)
        {
            this.authDAL = authDAL;
        }

        public async Task<int> CreateUser(UserModel model)
		{
			return await authDAL.CreateUser(model);
		}
	}
}
