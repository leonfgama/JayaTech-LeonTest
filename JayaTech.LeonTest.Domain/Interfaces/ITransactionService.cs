using JayaTech.LeonTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Domain.Interfaces
{
    public interface ITransactionService : IBaseService<Transaction>
    {
        Task<Transaction> MakeTransactionAsync(int userId, string sourceCurrency, decimal sourceAmount, string targetCurrency);
        Task<IEnumerable<Transaction>> GetTransactionsByUserId(int userId);
    }
}
