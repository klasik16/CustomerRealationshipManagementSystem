using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels
{
    public class ProfilePicture
    {
        [Key]
        public int ProfilePictureId { get; set; }

        public byte[]? ImageData { get; set; }

        // Foreign key
        public int UserId { get; set; }

        // Navigation property
        public virtual User? User { get; set; }
        //public IFormFile? ImageBytes { get; set; }


    }
}
