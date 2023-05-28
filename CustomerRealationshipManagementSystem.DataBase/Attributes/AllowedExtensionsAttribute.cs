using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRealationshipManagementSystem.DataBase.Attributes
{
    public class AllowedExtensionsAttribute: ValidationAttribute
    {
        private readonly string[] _allowedExtensions;
        public AllowedExtensionsAttribute(string[] allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_allowedExtensions.Contains(extension))
                {
                    return new ValidationResult("This file extension isn't supported");
                }
            }

            if (value is null)
            {
                // Handle the case where the value is null
                return new ValidationResult("The value cannot be null."); // or return an appropriate ValidationResult
            }
            return ValidationResult.Success!;
        }
    }
}

