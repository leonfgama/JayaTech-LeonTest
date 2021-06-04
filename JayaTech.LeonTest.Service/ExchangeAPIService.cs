using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Domain.Enum;
using JayaTech.LeonTest.Domain.Interfaces;
using JayaTech.LeonTest.Domain.ViewModels;
using JayaTech.LeonTest.Infrastruct.Config;
using JayaTech.LeonTest.Repository;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Service
{
    public class ExchangeAPIService
    {
        public ILogService LogService { get; set; }

        public ExchangeAPIService(ILogService logService)
        {
            this.LogService = logService;
        }

        private TransactionExchangeViewModel TransformExchangeToTransaction(ExchangeAPIViewModel exchange, decimal sourceAmount, string targetCurrency, long duration)
        {
            if (exchange == null)
                return null;

            decimal tax = exchange.Rates.FirstOrDefault(x => x.Key.ToUpper() == targetCurrency.ToUpper()).Value;

            TransactionExchangeViewModel transaction = new TransactionExchangeViewModel();
            transaction.Duration = duration;
            transaction.SourceCurrency = exchange.Base;
            transaction.SourceAmount = sourceAmount;
            transaction.TargetCurrency = targetCurrency;
            transaction.TargetAmount = tax * sourceAmount;
            transaction.Tax = tax;
            return transaction;
        }

        public async Task<TransactionExchangeViewModel> GetLatestExchangeAsync(string sourceCurrency, decimal sourceAmount, string targetCurrency)
        {
            if (string.IsNullOrWhiteSpace(sourceCurrency) ||
                sourceAmount == 0 ||
                string.IsNullOrWhiteSpace(targetCurrency))
                throw new ArgumentNullException("Please fill all fields!");

            Stopwatch watch = new Stopwatch();
            HttpClient _httpClient = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Settings.ExchangeURL);
            watch.Start();
            var response = await _httpClient.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            watch.Stop();

            if (!response.IsSuccessStatusCode)
            {
                this.LogService.Log(LogType.ExchangeApiCallDuration, false, "Call was Failed!", watch.ElapsedMilliseconds);
                throw new Exception("Call with external api was failed!");
            }


            this.LogService.Log(LogType.ExchangeApiCallDuration, true, "Call was Successful!", watch.ElapsedMilliseconds);

            var exchangeReturn = JsonConvert.DeserializeObject<ExchangeAPIViewModel>(content);
            return TransformExchangeToTransaction(exchangeReturn, sourceAmount, targetCurrency, watch.ElapsedMilliseconds);
        }
    }
}
