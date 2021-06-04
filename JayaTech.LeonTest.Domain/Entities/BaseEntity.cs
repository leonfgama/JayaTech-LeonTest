using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JayaTech.LeonTest.Domain.Entities
{
    public class BaseEntity : IValidatableObject
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (validationContext.Items != null)
            {
                foreach (var item in validationContext.Items)
                {
                    var teste = item;
                }
            }

            return new List<ValidationResult>();
        }
    }
}
