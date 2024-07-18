using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ISManager.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(100)]
        [MaxLength(100)]
        [Required]
        public string? Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastAccessDate { get; set; }
    }
}