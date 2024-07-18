using System.ComponentModel.DataAnnotations;
using ZedERP.Models.Entities.Product;

namespace ZedERP.Models
{
    public class UpdateProductDto
    {
        [Required]
        [StringLength(14)]
        public required string Code { get; set; }

        [Required]
        [StringLength(255)]
        public required string Name { get; set; }
        public int GroupId { get; set; }
        public int UnitId { get; set; }
    }
}
