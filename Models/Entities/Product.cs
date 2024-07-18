using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ZedERP.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(14)]
        public required string Code { get; set; }
        [Required]
        [StringLength(255)]
        public required string Name { get; set; }
    }
}
