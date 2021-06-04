using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JayaTech.LeonTest.Domain.Entities
{
    [Table("[transaction]")]
    public class Transaction :  BaseEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field User ID is required!")]
        public int UserId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Source Amount is required!")]
        public decimal SourceAmount { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Source Currency is required!")]
        public string SourceCurrency { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Target Amount is required!")]
        public decimal TargetAmount { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Target Currency is required!")]
        public string TargetCurrency { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Tax is required!")]
        public decimal Tax { get; set; }
    }
}