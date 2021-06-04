using JayaTech.LeonTest.Domain.Entities;
using System;

namespace JayaTech.LeonTest.Domain.Interfaces
{
    public interface ILogService : IBaseService<Log>
    {
        void LogApiCall(string message, long elapsedMilliseconds);
        void LogApiCallError(string message, long elapsedMilliseconds);
        void Log(Exception ex, bool sync = false);
    }
}
