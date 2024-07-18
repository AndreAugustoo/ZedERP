using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZedERP.Data;
using ZedERP.Models;
using ZedERP.Models.Entities;

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
            var allProducts = await dbContext.Products.ToListAsync();

            return Ok(allProducts);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await dbContext.Products.FindAsync(id);

            if (product is null)
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
            };

            await dbContext.Products.AddAsync(productEntity);
            await dbContext.SaveChangesAsync();

            return Ok(productEntity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            var product = await dbContext.Products.FindAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            product.Code = updateProductDto.Code;
            product.Name = updateProductDto.Name;

            await dbContext.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await dbContext.Products.FindAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
