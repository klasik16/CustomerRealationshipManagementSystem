using CustomerRealationshipManagementSystem.DataBase.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRealationshipManagementSystem.DataBase.Model.DTO
{
    public class UserSignupDTO
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? PersonalIdentificationNumber { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public AddressDTO? Address { get; set; }
        [Required]
        //[MaxFileSize(5 * 1024 * 1024)]
       // [AllowedExtensions(new string[] { ".png", ".jpg",".jpeg" })]
        public IFormFile? ProfilePicture { get; set; }
    }
}
