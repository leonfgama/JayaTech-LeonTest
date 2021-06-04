using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JayaTech.LeonTest.Service.ViewModels
{
    public class ExchangeAPIViewModel
    {
        public bool Success { get; set; }
        public int Timestamp { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
        public IDictionary<string, decimal> Rates { get; set; }
    }
}
