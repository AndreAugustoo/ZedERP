using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZedERP.Models.Entities.Product
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
        public int? GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group? Group { get; set; }

        public required int UnitId { get; set; }
        [ForeignKey("UnitId")]
        public Unit? Unit { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public required decimal SalePrice { get; set; }

        public int? Stock { get; set; }

        public string? Image { get; set; }
    }
}
