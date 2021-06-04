using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Domain.Interfaces;
using JayaTech.LeonTest.Service;
using JayaTech.LeonTest.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.WebAPI.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _userService;
        private ILogService _logService;

        public UserController(IUserService userService, ILogService logService)
            : base(logService)
        {
            this._userService = userService;
            this._logService = logService;
        }

        [HttpGet]
        [Route("api/hello")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Hello()
        {   
            return new
            {
                Name = "Leon Fernandes Gama Bezerra",
                Age = 26,
                Sons = new List<dynamic>() { 
                    new {
                        Name = "Cristina Mariano Gama Bezerra",
                        Age = 1.3
                    }
                },
                LinkedIn = "https://www.linkedin.com/in/leonfgama",
                GitHubProfile = "https://github.com/leonfgama",
                ProjectDocumentation = "https://github.com/leonfgama/JayaTech-LeonTest"
            };
        }

            [HttpPost]
        [Route("api/user/login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] User model)
        {
            var user = await this._userService.Login(model);

            if (user == null)
                return NotFound(new { message = "User or password is incorrect!" });

            var token = TokenService.GenerateToken(user);
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpPost]
        [Route("api/user/createAccount")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> CreateAccount([FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return await base.ExecuteAsync(() => this._userService.CreateAccountAsync(model).Result);
        }
    }
}