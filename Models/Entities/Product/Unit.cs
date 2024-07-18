using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZedERP.Models.Entities.Product
{
    public class Unit
    {
        public int Id { get; set; }

        [Required]
        [StringLength(4)]
        public required string UnitSymbol { get; set; }

        [Required]
        [StringLength(50)]
        public required string Description { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
