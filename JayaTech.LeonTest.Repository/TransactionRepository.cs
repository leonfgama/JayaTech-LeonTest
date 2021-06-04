using JayaTech.LeonTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JayaTech.LeonTest.Repository
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository()
            : base("Transaction")
        {
        }
    }
}
