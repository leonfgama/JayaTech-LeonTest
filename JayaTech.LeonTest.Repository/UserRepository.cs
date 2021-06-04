using Dapper;
using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository()
            : base("User")
        {
        }

        public async Task<bool> CheckEmailExistAsync(string email)
        {
            return await this.Connection.QueryFirstOrDefaultAsync<bool>(@"SELECT 1 FROM [USER] WHERE EMAIL = @Email", new { Email = email });
        }

        public async Task<bool> CheckUsernameExistAsync(string username)
        {
            return await this.Connection.QueryFirstOrDefaultAsync<bool>(@"SELECT 1 FROM [USER] WHERE USERNAME = @Username", new { Username = username });
        }

        public async Task<UserLoginViewModel> Login(string username, string password)
        {
            return await this.Connection.QueryFirstOrDefaultAsync<UserLoginViewModel>(@"SELECT * FROM [USER] WHERE USERNAME = @Username AND Password = @Password", new { Username = username, Password = password });
        }
    }
}
