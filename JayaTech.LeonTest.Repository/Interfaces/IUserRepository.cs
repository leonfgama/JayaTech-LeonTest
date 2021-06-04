using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> CheckUsernameExistAsync(string username);
        Task<bool> CheckEmailExistAsync(string email);
        Task<UserLoginViewModel> Login(string username, string password);
    }
}
