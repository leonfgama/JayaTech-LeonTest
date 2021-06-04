using JayaTech.LeonTest.Mock;
using JayaTech.LeonTest.Repository;
using JayaTech.LeonTest.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Test
{
    [TestClass]
    public class UserTest
    {
        public UserTest()
        {
            this.UserMock = new UserMock();
            this.UserService = new UserService(new UserRepository());
        }
        public UserService UserService { get; set; }
        public UserMock UserMock { get; set; }

        [TestMethod]
        public void TestCRUD()
        {
            var user = this.UserMock.GetOneRandom();

            var insertedUser = this.UserService.InsertAsync(user).Result;

            Assert.AreEqual(user.Username, insertedUser.Username);

            this.UserService.Delete(insertedUser);

            var deletedUser = this.UserService.GetAsync(insertedUser.Id).Result;

            Assert.IsNull(deletedUser);
        }
    }
}