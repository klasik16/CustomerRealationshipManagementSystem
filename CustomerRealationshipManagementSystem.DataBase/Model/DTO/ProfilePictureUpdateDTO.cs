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
    public class ProfilePictureUpdateDTO
    {
        [Required]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".png", ".jpg", ".jpeg" })]
        public IFormFile? ProfilePicture { get; set; }
    }
}
