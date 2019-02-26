using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SchoolJournalModels
{
    public class CustomValidation
    {
        public sealed class CheckStatus:ValidationAttribute
        {
            public string AllowStatus { get; set; }

            protected override ValidationResult IsValid(object status, ValidationContext validationContext)
            {
                string[] myArr = AllowStatus.ToString().Split(',');
                if (myArr.Contains(status))
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Choose a valid status eg.'TO DO', 'IN PROGRESS', 'FINISHED'.");
            }
        }
    }
}
