using JayaTech.LeonTest.Domain.Entities;
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
            try
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
                    // TODO Log
                }

                //TODO Log
                var exchangeReturn =  JsonConvert.DeserializeObject<ExchangeAPIViewModel>(content);
                return TransformExchangeToTransaction(exchangeReturn, sourceAmount, targetCurrency, watch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
