using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JayaTech.LeonTest.Domain.ViewModels
{
    public class UserViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field username is required!")]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field e-mail is required!")]
        public string Email { get; set; }
        [EmailAddress]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field Fullname is required!")]
        public string Fullname { get; set; }
    }
}
