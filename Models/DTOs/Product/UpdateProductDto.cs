using ZedERP.Models.DTOs.Product.Group;
using ZedERP.Models.DTOs.Product.Unit;

namespace ZedERP.Models.DTOs.Product
{
    public class UpdateProductDto
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public int? GroupId { get; set; }
        public int UnitId { get; set; }
        public required decimal SalePrice { get; set; }
        public int? Stock { get; set; }
        public string? Image { get; set; }

        public UpdateGroupDto? Group { get; set; }
        public UpdateUnitDto? Unit { get; set; }
    }
}
