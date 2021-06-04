using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Repository;
using System;

namespace JayaTech.LeonTest.Service
{
    public class UserService : BaseService<User>, IBaseService<User>
    {
        public UserService(UserRepository userRepository)
            : base(userRepository)
        {
            this.UserRepository = userRepository;
        }

        public UserRepository UserRepository { get; set; }
    }
}
