using System.ComponentModel.DataAnnotations;

namespace ZedERP.Models.DTOs.Product
{
    public class AddProductDto
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
