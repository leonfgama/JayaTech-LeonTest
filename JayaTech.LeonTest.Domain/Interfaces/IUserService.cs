using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Domain.ViewModels;
using System;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Domain.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        Task<UserViewModel> CreateAccountAsync(User user);
        Task<UserLoginViewModel> Login(User user);
    }
}
