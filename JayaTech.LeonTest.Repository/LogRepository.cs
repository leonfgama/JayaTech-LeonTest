using Dapper;
using Dapper.Contrib.Extensions;
using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Repository
{
    public class LogRepository : BaseRepository<Log>, ILogRepository
    {
        public LogRepository()
            : base("Log")
        {            
        }

        public async Task<int> GetCountAsync()
        {
            return await this.Connection.QueryFirstAsync<int>(@"SELECT COUNT(0) FROM [Log]");
        }

        public async Task<IEnumerable<LogReportViewModel>> GetLogReport()
        {
            return await this.Connection.QueryAsync<LogReportViewModel>(@"SELECT [Type] AS [LogType], COUNT(0) AS [Count], AVG(DURATION) AS [AvgDuration] FROM [LOG] GROUP BY [TYPE]");
        }
    }
}
