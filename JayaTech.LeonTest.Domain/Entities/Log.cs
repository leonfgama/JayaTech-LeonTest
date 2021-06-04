using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JayaTech.LeonTest.Domain.Entities
{
    [Table("[log]")]
    public class Log : BaseEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Type is required!")]
        public int Type { get; set; }
        public long? Duration { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Is Success is required!")]
        public bool IsSuccess { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Text is required!")]
        public string Text { get; set; }
    }
}
