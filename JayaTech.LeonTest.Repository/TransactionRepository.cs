using JayaTech.LeonTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JayaTech.LeonTest.Repository
{
    public class TransactionRepository : BaseRepository<Transaction>, IBaseRepository<Transaction>
    {
        public TransactionRepository()
            : base("Transaction")
        {
        }
    }
}
