using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JayaTech.LeonTest.Service.ViewModels
{
    public class TransactionExchangeViewModel
    {
        public long Duration { get; set; }
        public string SourceCurrency { get; set; }
        public decimal SourceAmount { get; set; }
        public string TargetCurrency { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal Tax { get; set; }
    }
}
