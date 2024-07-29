namespace ZedERP.Models.DTOs.Product.Unit
{
    public class UpdateUnitDto
    {
        public required int Id { get; set; }
        public required string UnitSymbol { get; set; }
        public required string Description { get; set; }
    }
}
