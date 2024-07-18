using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZedERP.Models.Entities.Product
{
    public class Group
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
