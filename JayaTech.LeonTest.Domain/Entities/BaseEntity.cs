using System;
using System.Collections.Generic;
using System.Text;

namespace JayaTech.LeonTest.Domain.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
