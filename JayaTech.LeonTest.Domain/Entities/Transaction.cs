using System;
using System.Collections.Generic;
using System.Text;

namespace JayaTech.LeonTest.Domain.Entities
{
    public class Transaction :  BaseEntity
    {
        public int UserId { get; set; }
        public decimal SourceAmount { get; set; }
        public string SourceCurrency { get; set; }
        public decimal TargetAmount { get; set; }
        public string TargetCurrency { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Tax { get; set; }

    }
}
