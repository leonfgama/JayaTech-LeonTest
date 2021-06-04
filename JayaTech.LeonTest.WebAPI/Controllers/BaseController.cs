﻿using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Domain.Interfaces;
using JayaTech.LeonTest.Domain.ViewModels;
using JayaTech.LeonTest.Service;
using JayaTech.LeonTest.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.WebAPI.Controllers
{
    public class BaseController : Controller
    {
        private ILogService _logService;
        public BaseController(ILogService logService)
        {
            this._logService = logService;
        }
        protected async Task<HttpResponseMessageViewModel> ExecuteAsync(Func<object> action, string message = "Call was Successful!", bool isSuccess = true)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                var result = action();
                sw.Stop();
                this._logService.LogApiCall($"", sw.ElapsedMilliseconds);

                HttpResponseMessageViewModel entity = new HttpResponseMessageViewModel(isSuccess, message, result);
                return entity;
            }
            catch (Exception ex)
            {   
                sw.Stop();
                this._logService.LogApiCallError(ex.Message, sw.ElapsedMilliseconds);
                HttpResponseMessageViewModel entity = new HttpResponseMessageViewModel(ex.Message, ex);
                return entity;
            }
        }
    }
}
