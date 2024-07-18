using ZedERP.Models.DTOs.Product.Unit;
using ZedERP.Models.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ZedERP.Data;

namespace ZedERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public UnitsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUnits()
        {
            var allUnits = await dbContext.Units.ToListAsync();

            return Ok(allUnits);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUnitById(int id)
        {
            var unit = await dbContext.Units.FirstOrDefaultAsync(u => u.Id == id);

            if (unit == null)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        [HttpPost]
        public async Task<IActionResult> AddUnit(AddUnitDto addUnitDto)
        {
            var unitEntity = new Unit()
            {
                UnitSymbol = addUnitDto.UnitSymbol,
                Description = addUnitDto.Description,
            };

            await dbContext.Units.AddAsync(unitEntity);
            await dbContext.SaveChangesAsync();

            return Ok(unitEntity);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUnit(int id, UpdateUnitDto updateUnitDto)
        {
            var unit = await dbContext.Units.FindAsync(id);

            if (unit == null)
            {
                return NotFound();
            }

            unit.UnitSymbol = updateUnitDto.UnitSymbol;
            unit.Description = updateUnitDto.Description;

            await dbContext.SaveChangesAsync();

            return Ok(unit);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            var unit = await dbContext.Units.FindAsync(id);

            if (unit == null)
            {
                return NotFound();
            }

            dbContext.Units.Remove(unit);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
