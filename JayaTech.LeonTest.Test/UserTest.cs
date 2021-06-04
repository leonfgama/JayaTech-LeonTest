using JayaTech.LeonTest.Mock;
using JayaTech.LeonTest.Repository;
using JayaTech.LeonTest.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JayaTech.LeonTest.Test
{
    [TestClass]
    public class UserTest : ITestBase
    {
        public UserTest()
        {
            this.UserMock = new UserMock();
            this.UserService = new UserService(new UserRepository());
        }
        public UserService UserService { get; set; }
        public UserMock UserMock { get; set; }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Insert()
        {
            var user = this.UserMock.GetOneRandom();

            var insertedUser = this.UserService.InsertAsync(user).Result;

            Assert.AreEqual(user.Username, insertedUser.Username);

        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
