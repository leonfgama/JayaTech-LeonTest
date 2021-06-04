using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Domain.Interfaces;
using JayaTech.LeonTest.Domain.ViewModels;
using JayaTech.LeonTest.Infrastruct.Config;
using JayaTech.LeonTest.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Service
{
    public class TransactionService : BaseService<Transaction>, ITransactionService
    {
        public ExchangeAPIService ExchangeAPIService { get; set; }
        public ILogService LogService { get; set; }
        public ITransactionRepository TransactionRepository { get; set; }
        public TransactionService(ILogService logService, ITransactionRepository transactionRepository)
            : base(transactionRepository)
        {   
            this.ExchangeAPIService = new ExchangeAPIService(logService);
            this.LogService = logService;
            this.TransactionRepository = transactionRepository;
        }

        private Transaction ToTransaction(TransactionExchangeViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("View Model is Null");

            Transaction transaction = new Transaction();
            transaction.SourceCurrency = viewModel.SourceCurrency;
            transaction.SourceAmount = viewModel.SourceAmount;
            transaction.TargetCurrency = viewModel.TargetCurrency;
            transaction.TargetAmount = viewModel.TargetAmount;
            transaction.Tax = viewModel.Tax;

            return transaction;
        }

        public async Task<Transaction> MakeTransactionAsync(int userId, string sourceCurrency, decimal sourceAmount, string targetCurrency)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sourceCurrency) ||
                            sourceAmount == 0 ||
                            string.IsNullOrWhiteSpace(targetCurrency))
                    throw new ArgumentNullException("Please fill all fields!");

                var transactionViewModel = await this.ExchangeAPIService.GetLatestExchangeAsync(sourceCurrency, sourceAmount, targetCurrency);
                var transaction = this.ToTransaction(transactionViewModel);
                transaction.UserId = userId;

                transaction = await base.InsertAsync(transaction);

                this.LogService.Log(Domain.Enum.LogType.TransactionSuccess, true, "Transaction was success!");

                return transaction;
            }
            catch (Exception ex)
            {
                this.LogService.Log(Domain.Enum.LogType.TransactionFailed, false, "Transaction was failed!");
                throw new Exception("An error occurred while trying to create a transaction");
            }
        }

        public Task<IEnumerable<Transaction>> GetTransactionsByUserId(int userId)
        {
            return this.TransactionRepository.GetTransactionByUserId(userId);
        }
    }
}