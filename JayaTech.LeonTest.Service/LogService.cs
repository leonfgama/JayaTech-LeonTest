using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Domain.Enum;
using JayaTech.LeonTest.Domain.Interfaces;
using JayaTech.LeonTest.Domain.ViewModels;
using JayaTech.LeonTest.Infrastruct.Config;
using JayaTech.LeonTest.Repository;
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
    public class LogService : BaseService<Log>, ILogService
    {
        public ILogRepository LogRepository { get; set; }
        public LogService(ILogRepository logRepository)
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

        public void LogApiCall(string message, long elapsedMilliseconds)
        {
            Task.Run(() =>
            {
                Log obj = new Log();
                obj.IsSuccess = true;
                obj.Type = (int)LogType.ApiCall;
                obj.Text = message;
                obj.Duration = elapsedMilliseconds;

                Task.Run(() => base.InsertAsync(obj));
            });
        }

        public void LogApiCallError(string message, long elapsedMilliseconds)
        {
            Task.Run(() =>
            {
                Log obj = new Log();
                obj.IsSuccess = false;
                obj.Type = (int)LogType.ApiCallError;
                obj.Text = message;
                obj.Duration = elapsedMilliseconds;

                Task.Run(() => base.InsertAsync(obj));
            });
        }

        public IEnumerable<LogTypesViewModel> GetLogTypes()
        {
            List<LogTypesViewModel> logTypes = new List<LogTypesViewModel>();
            logTypes.Add(new LogTypesViewModel(1, "Login Success"));
            logTypes.Add(new LogTypesViewModel(2, "Login Failed"));
            logTypes.Add(new LogTypesViewModel(3, "Transaction Success"));
            logTypes.Add(new LogTypesViewModel(4, "Transaction Failed"));
            logTypes.Add(new LogTypesViewModel(5, "Exchange API Call Duration"));
            logTypes.Add(new LogTypesViewModel(6, "Exception"));
            logTypes.Add(new LogTypesViewModel(7, "API Call"));
            logTypes.Add(new LogTypesViewModel(8, "API Call Error"));

            return logTypes;
        }

        public async Task<IEnumerable<LogReportViewModel>> GetLogReport()
        {
            var logs = await this.LogRepository.GetLogReport();
            if (logs != null)
            {
                logs.ToList().ForEach(x => 
                {
                    x.LogTypeTitle = LogTypeHelper.GetLogTypeTitle(x.LogType);
                    x.AvgTime = x.AvgDuration > 0 ? $"{x.AvgDuration / 1000} Seconds" : "0 Seconds";
                });
            }

            return logs;
        }

        public void Log(LogType type, bool success, string message, long? duration)
        {
            Task.Run(() =>
            {
                Log obj = new Log();
                obj.IsSuccess = success;
                obj.Type = (int)type;
                obj.Text = message;
                obj.Duration = duration;

                Task.Run(() => base.InsertAsync(obj));
            });
        }
    }
}