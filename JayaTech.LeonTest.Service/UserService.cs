using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Domain.Enum;
using JayaTech.LeonTest.Domain.Interfaces;
using JayaTech.LeonTest.Domain.ViewModels;
using JayaTech.LeonTest.Infrastruct.Helpers;
using JayaTech.LeonTest.Repository;
using System;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUserRepository userRepository)
            : base(userRepository)
        {
            this.UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; set; }

        public async Task<UserViewModel> CreateAccountAsync(User user)
        {
            if (user == null)
                throw new Exception("Model is empty!");

            if (await this.UserRepository.CheckEmailExistAsync(user.Email))
                throw new Exception($"This email {user.Email} already exists");

            if (await this.UserRepository.CheckUsernameExistAsync(user.Username))
                throw new Exception($"This username {user.Username} already exists");

            user.Password = CryptHelper.EncryptPassword(user.Password);

            user = await base.InsertAsync(user);


            var viewModel = new UserViewModel();
            viewModel.Username = user.Username;
            viewModel.Email = user.Email;
            viewModel.Fullname = user.Fullname;
            return viewModel;
        }

        public async Task<UserLoginViewModel> Login(User user)
        {
            string passwordEncrypted = CryptHelper.EncryptPassword(user.Password);
            return await this.UserRepository.Login(user.Username, passwordEncrypted);
        }
    }
}
