using System.ComponentModel.DataAnnotations;

namespace ZedERP.Models
{
    public class AddProductDto
    {
        [Required]
        [StringLength(14)]
        public required string Codigo { get; set; }
        [Required]
        [StringLength(255)]
        public required string Name { get; set; }
    }
}
