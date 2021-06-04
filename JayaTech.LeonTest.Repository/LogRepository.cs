using Dapper;
using Dapper.Contrib.Extensions;
using JayaTech.LeonTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Repository
{
    public class LogRepository : BaseRepository<Log>, IBaseRepository<Log>
    {
        public LogRepository()
            : base("Log")
        {            
        }

        public async Task<int> GetCountAsync()
        {
            return await this.Connection.QueryFirstAsync<int>(@"SELECT COUNT(0) FROM [Log]");
        }
    }
}
