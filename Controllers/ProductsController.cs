using ZedERP.Models.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ZedERP.Data;
using ZedERP.Models.DTOs.Product;
using ZedERP.Models.DTOs.Product.Group;
using ZedERP.Models.DTOs.Product.Unit;

namespace ZedERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ProductsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var allProducts = await dbContext.Products
                .Include(p => p.Group)
                .Include(p => p.Unit)
                .Select(p => new UpdateProductDto
                {
                    Code = p.Code,
                    Name = p.Name,
                    Group = p.Group != null ? new UpdateGroupDto
                    {
                        Id = p.Group.Id,
                        Name = p.Group.Name
                    } : null,
                    Unit = p.Unit != null ? new UpdateUnitDto
                    {
                        Id = p.Unit.Id,
                        UnitSymbol = p.Unit.UnitSymbol,
                        Description = p.Unit.Description,
                    } : null,
                    SalePrice = p.SalePrice,
                    Stock = p.Stock,
                    Image = p.Image
                })
                .ToListAsync();

            return Ok(allProducts);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await dbContext.Products
        .Include(p => p.Group)
        .Include(p => p.Unit)
        .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = new UpdateProductDto
            {
                Code = product.Code,
                Name = product.Name,
                Group = product.Group != null ? new UpdateGroupDto
                {
                    Id = product.Group.Id,
                    Name = product.Group.Name
                } : null,
                Unit = product.Unit != null ? new UpdateUnitDto
                {
                    Id = product.Unit.Id,
                    UnitSymbol = product.Unit.UnitSymbol,
                    Description= product.Unit.Description,
                } : null,
                SalePrice = product.SalePrice,
                Stock = product.Stock,
                Image = product.Image
            };

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto addProductDto)
        {
            var productEntity = new Product()
            {
                Code = addProductDto.Code,
                Name = addProductDto.Name,
                GroupId = addProductDto.GroupId,
                UnitId = addProductDto.UnitId,
                SalePrice = addProductDto.SalePrice,
                Stock = addProductDto.Stock,
                Image = addProductDto.Image,
            };

            await dbContext.Products.AddAsync(productEntity);
            await dbContext.SaveChangesAsync();

            return Ok(productEntity);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            var product = await dbContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Code = updateProductDto.Code;
            product.Name = updateProductDto.Name;
            product.GroupId = updateProductDto.GroupId;
            product.UnitId = updateProductDto.UnitId;
            product.SalePrice = updateProductDto.SalePrice;
            product.Stock = updateProductDto.Stock;
            product.Image = updateProductDto.Image;

            await dbContext.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await dbContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
