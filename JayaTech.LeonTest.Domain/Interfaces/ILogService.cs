using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Domain.Enum;
using JayaTech.LeonTest.Domain.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Domain.Interfaces
{
    public interface ILogService : IBaseService<Log>
    {
        void LogApiCall(string message, long elapsedMilliseconds);
        void LogApiCallError(string message, long elapsedMilliseconds);
        void Log(Exception ex, bool sync = false);
        void Log(LogType type, bool success, string message, long? duration = null);
        IEnumerable<LogTypesViewModel> GetLogTypes();
        Task<IEnumerable<LogReportViewModel>> GetLogReport();
    }
}
