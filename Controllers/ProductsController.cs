using ZedERP.Models.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ZedERP.Data;
using ZedERP.Models.DTOs.Product;

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
                .Select(p => new UpdateProductDto
                {
                    Code = p.Code,
                    Name = p.Name,
                    GroupId = p.GroupId,
                    UnitId = p.UnitId,
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
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
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
