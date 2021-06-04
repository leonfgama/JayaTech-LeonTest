using Dapper;
using JayaTech.LeonTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Repository
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository()
            : base("Transaction")
        {
        }

        public async Task<IEnumerable<Transaction>> GetTransactionByUserId(int userId)
        {
            return await this.Connection.QueryAsync<Transaction>($"SELECT * FROM [TRANSACTION] WHERE UserId = @UserId", new { UserId = userId });
        }
    }
}
