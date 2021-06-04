using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Domain.Interfaces;
using JayaTech.LeonTest.Domain.ViewModels;
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
        [Route("api/transaction")]
        public async Task<ActionResult<dynamic>> MakeTransaction([FromBody] TransactionViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Workaround Free Plan
            model.SourceCurrency = "EUR";

            return await base.ExecuteAsync(() => this._transactionService.MakeTransactionAsync(this.GetUserId(), model.SourceCurrency, model.SourceAmount, model.TargetCurrency).Result);
        }

        [HttpGet]
        [Route("api/transaction/getmytransactions")]
        public async Task<ActionResult<dynamic>> GetCurrentUser()
        {
            return await base.ExecuteAsync(() => this._transactionService.GetTransactionsByUserId(this.GetUserId()).Result);
        }

        [HttpGet]
        [Route("api/transaction/get")]
        public async Task<ActionResult<dynamic>> GetByUserId([FromQuery] int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await base.ExecuteAsync(() => this._transactionService.GetTransactionsByUserId(userId).Result);
        }
    }
}