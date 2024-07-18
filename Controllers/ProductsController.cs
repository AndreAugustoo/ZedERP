using ZedERP.Models.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ZedERP.Models;
using ZedERP.Data;

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
                UnitId = addProductDto.UnitId
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
