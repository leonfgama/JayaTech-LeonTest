using System;
using System.Collections.Generic;
using System.Text;

namespace JayaTech.LeonTest.Domain.Entities
{
    public class User : BaseEntity
    {   
        public string Username { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
    }
}
