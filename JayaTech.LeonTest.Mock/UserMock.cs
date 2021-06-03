using JayaTech.LeonTest.Domain.Entities;
using System;
using System.Collections.Generic;

namespace JayaTech.LeonTest.Mock
{
    public class UserMock : ImockBase<User>
    {
        public IEnumerable<User> GetManyRandom(int length)
        {
            throw new NotImplementedException();
        }

        public User GetOne()
        {
            throw new NotImplementedException();
        }

        public User GetOneRandom()
        {
            throw new NotImplementedException();
        }
    }
}
