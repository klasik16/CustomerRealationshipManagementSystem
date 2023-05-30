using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(100)]
        public string? Street { get; set; }

        [MaxLength(10)]
        public string? BuildingNumber { get; set; }

        [MaxLength(10)]
        public string? ApartmentNumber { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}
