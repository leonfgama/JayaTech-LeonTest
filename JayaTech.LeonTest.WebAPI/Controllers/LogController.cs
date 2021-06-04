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
    public class LogController : BaseController
    {
        private ILogService _logService;

        public LogController(ILogService logService)
            : base(logService)
        {
            this._logService = logService;
        }

        [HttpGet]
        [Route("api/log/types")]
        [AllowAnonymous]
        public dynamic GetLogTypes()
        {
            return base.Execute(() => this._logService.GetLogTypes());
        }

        [HttpGet]
        [Route("api/log/getlogreport")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> GetLogReport()
        {
            return await base.ExecuteAsync(() => this._logService.GetLogReport().Result);
        }
    }
}
