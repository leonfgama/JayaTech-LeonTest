using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JayaTech.LeonTest.Repository
{
    public class UserRepository : BaseRepository<User>, IBaseRepository<User>
    {
        public UserRepository()
            : base("User")
        {
        }
    }
}
