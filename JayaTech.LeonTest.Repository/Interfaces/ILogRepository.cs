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
    public interface ILogRepository : IBaseRepository<Log>
    {
        Task<int> GetCountAsync();
    }
}
