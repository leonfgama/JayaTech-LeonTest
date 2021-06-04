using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JayaTech.LeonTest.Domain.ViewModels
{
    public class TransactionViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Source Currency is required!")]
        public string SourceCurrency { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Source Amount is required!")]
        public decimal SourceAmount { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Target Amount is required!")]
        public string TargetCurrency { get; set; }


    }
}
