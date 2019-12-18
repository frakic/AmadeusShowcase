using System;
using System.ComponentModel.DataAnnotations;

namespace AmadeusShowcase.Service
{
    public class ValidationDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((DateTime)value >= DateTime.Today)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Datum ne može biti u prošlosti.");
            }
        }
    }
}
