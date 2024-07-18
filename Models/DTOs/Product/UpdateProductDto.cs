using System.ComponentModel.DataAnnotations;
using ZedERP.Models.Entities.Product;

namespace ZedERP.Models.DTOs.Product
{
    public class UpdateProductDto
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public int? GroupId { get; set; }
        public required int UnitId { get; set; }
        public required decimal SalePrice { get; set; }
        public int? Stock { get; set; }
        public string? Image { get; set; }
    }
}
