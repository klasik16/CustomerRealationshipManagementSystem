using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        // Foreign keys
        public int UserId { get; set; }
        public int RoleId { get; set; }

        // Navigation properties
        public virtual User? User { get; set; }
        public virtual Role? Role { get; set; }
        public string? RoleName { get; set; }
    }
}
