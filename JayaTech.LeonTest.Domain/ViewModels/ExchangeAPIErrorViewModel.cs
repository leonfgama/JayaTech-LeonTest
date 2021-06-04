using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JayaTech.LeonTest.Domain.ViewModels
{
    public class ExchangeAPIErrorViewModel
    {
        public ExchangeAPIErrorContentViewModel error { get; set; }
    }

    public class ExchangeAPIErrorContentViewModel
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
