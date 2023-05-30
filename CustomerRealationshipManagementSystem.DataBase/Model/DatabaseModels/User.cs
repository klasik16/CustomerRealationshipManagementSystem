using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels
{


    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required]
        [MaxLength(11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Personal Identification Number must be 11 digits.")]
        public string? PersonalIdentificationNumber { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string? Email { get; set; }

        [Phone]
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        // Navigation properties
        public Role UserRoles { get; set; }
        public Address? Address { get; set; }
        public ProfilePicture? ProfilePicture { get; set; }
    }
}
