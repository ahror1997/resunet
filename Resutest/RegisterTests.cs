using Resutest.Helpers;
using System.Transactions;

namespace Resutest
{
    public class RegisterTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task BaseRegistrationTest()
        {
            using (TransactionScope scope = Helper.CreateTransactionScope())
            {
                string email = Guid.NewGuid().ToString() + "@test.com";

                // validate: should not be in the db
                var emailValidationResult = await authBL.ValidateEmail(email);
                Assert.IsNull(emailValidationResult);

                // create a user
                int userId = await authBL.CreateUser(
                    new Resunet.DAL.Models.UserModel()
                    {
                        Email = email,
                        Password = "qwert12345"
                    });
                Assert.Greater(userId, 0);

                // validate: should be in the db
                emailValidationResult = await authBL.ValidateEmail(email);
                Assert.IsNotNull(emailValidationResult);
            }
        }
    }
}