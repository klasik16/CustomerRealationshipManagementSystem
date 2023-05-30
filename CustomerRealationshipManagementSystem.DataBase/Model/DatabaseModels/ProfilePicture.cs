using CustomerRealationshipManagementSystem.DataBase.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        public Guid Id { get; set; }

        public byte[] ImageData { get; set; }

        // Navigation property
        public User User { get; set; }

    }
}
