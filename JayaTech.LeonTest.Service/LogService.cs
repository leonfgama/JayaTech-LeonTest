using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Domain.Enum;
using JayaTech.LeonTest.Infrastruct.Config;
using JayaTech.LeonTest.Repository;
using JayaTech.LeonTest.Service.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Service
{
    public class LogService : BaseService<Log>, IBaseService<Log>
    {
        public LogRepository LogRepository { get; set; }
        public LogService(LogRepository logRepository)
            : base(logRepository)
        {
            this.LogRepository = logRepository;
        }

        public void Log(Exception ex, bool sync = false)
        {
            if (sync)
            {
                Log obj = new Log();
                obj.IsSuccess = false;
                obj.Type = (int)LogType.Exception;
                obj.Text = ex.Message;

                var log = base.InsertAsync(obj).Result;
            }
            else
            {
                Task.Run(() =>
                {
                    Log obj = new Log();
                    obj.IsSuccess = false;
                    obj.Type = (int)LogType.Exception;
                    obj.Text = ex.Message;

                    Task.Run(() => base.InsertAsync(obj));
                });
            }            
        }

        public async Task<int> GetCountAsync()
        {
            return await this.LogRepository.GetCountAsync();
        }
    }
}