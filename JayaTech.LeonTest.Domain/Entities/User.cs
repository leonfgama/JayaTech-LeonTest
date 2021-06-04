using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JayaTech.LeonTest.Domain.Entities
{
    [Table("[user]")]
    public class User : BaseEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field username is required!")]
        public string Username { get; set; }
        [EmailAddress]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field e-mail is required!")]
        public string Email { get; set; }        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Fullname is required!")]
        public string Fullname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Password is required!")]
        public string Password { get; set; }       
    }
}
