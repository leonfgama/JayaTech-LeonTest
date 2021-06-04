using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Infrastruct.Helpers;
using System;
using System.Collections.Generic;

namespace JayaTech.LeonTest.Mock
{
    public class UserMock : IMockBase<User>
    {
        public IEnumerable<User> GetManyRandom(int length)
        {
            var list = new List<User>();
            for (int i = 0; i < length; i++)
            {
                var obj = this.GetOneRandom();
                list.Add(obj);
                i++;
            }

            return list;
        }

        public User GetOne()
        {
            User obj = new User();
            obj.Username = "leonfgama";
            obj.Email = "leonfgama@gmail.com";
            obj.Fullname = "Leon Fernandes Gama Bezerra";
            obj.Password = "123123";
            return obj;
        }

        public User GetOneRandom()
        {
            User obj = new User();
            obj.Username = MockHelper.GenerateRandomString(7);
            obj.Email = MockHelper.GenerateRandomString(6, false, StringCaseStyle.EmailCase);
            obj.Fullname = MockHelper.GenerateRandomString(15, false, StringCaseStyle.TitleCase);
            obj.Password = MockHelper.GenerateRandomString(6, true);
            return obj;
        }
    }
}
