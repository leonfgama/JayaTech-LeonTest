using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Infrastruct.Helpers;
using System;
using System.Collections.Generic;

namespace JayaTech.LeonTest.Mock
{
    public class TransactionMock : IMockBase<Transaction>
    {
        public IEnumerable<Transaction> GetManyRandom(int length)
        {
            throw new NotImplementedException();
        }

        public Transaction GetOne()
        {
            throw new NotImplementedException();
        }

        public Transaction GetOneRandom()
        {
            throw new NotImplementedException();
        }
    }
}
