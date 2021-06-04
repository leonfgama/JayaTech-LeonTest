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
    public class TransactionController : BaseController
    {
        private IUserService _userService;
        private ITransactionService _transactionService;
        private ILogService _logService;

        public TransactionController(IUserService userService, ITransactionService transactionService, ILogService logService)
            : base(logService)
        {
            this._userService = userService;
            this._transactionService = transactionService;
            this._logService = logService;
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