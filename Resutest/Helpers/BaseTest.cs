using Resunet.DAL;
using Resunet.BL.Auth;
using Microsoft.AspNetCore.Http;

namespace Resutest.Helpers
{
    public class BaseTest
    {
        protected IAuthDAL authDAL = new AuthDAL();
        protected IEncrypt encrypt = new Encrypt();
        protected IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
        protected IAuthBL authBL;

        public BaseTest()
        {
            this.authBL = new AuthBL(authDAL, encrypt, httpContextAccessor);
        }
    }
}
