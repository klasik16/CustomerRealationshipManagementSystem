﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRealationshipManagementSystem.DataBase.Model.DTO
{
    public class AddressDTO
    {
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Street { get; set; }
        [Required]
        public string? BuildingNumber { get; set; }
        [Required]
        public string? ApartmentNumber { get; set; }
    }
}
