using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public string? UserRole { get; set; }

        // Navigation property
        //public User User { get; set; }

    }
}
