using JayaTech.LeonTest.Infrastruct.Helpers;
using JayaTech.LeonTest.Mock;
using JayaTech.LeonTest.Repository;
using JayaTech.LeonTest.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Test
{
    [TestClass]
    public class TransactionTest
    {
        public TransactionTest()
        {
            this.TransactionService = new TransactionService(new LogService(new LogRepository()), new TransactionRepository());
        }
        public TransactionService TransactionService { get; set; }

        [TestMethod]
        public void MakeTransactionTest()
        {
            string sourceCurrency = "EUR";
            decimal sourceAmount = MockHelper.GenerateRandomDecimal(1, 10000);
            string targetCurrency = "BRL";

            var transaction = this.TransactionService.MakeTransactionAsync(35, sourceCurrency, sourceAmount, targetCurrency).Result;

            Assert.IsNotNull(transaction);
        }
    }
}