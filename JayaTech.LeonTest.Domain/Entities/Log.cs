using System;
using System.Collections.Generic;
using System.Text;

namespace JayaTech.LeonTest.Domain.Entities
{
    public class Log : BaseEntity
    {
        public int Type { get; set; }
        public int Duration { get; set; }
        public bool IsSuccess { get; set; }
        public string Text { get; set; }
    }
}
