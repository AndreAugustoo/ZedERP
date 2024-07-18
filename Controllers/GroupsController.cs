using ZedERP.Models.DTOs.Product.Group;
using ZedERP.Models.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ZedERP.Data;

namespace ZedERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public GroupsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            var allGroups = await dbContext.Groups.ToListAsync();

            return Ok(allGroups);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            var group = await dbContext.Groups.FirstOrDefaultAsync(u => u.Id == id);

            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        [HttpPost]
        public async Task<IActionResult> AddGroup(AddGroupDto addGroupDto)
        {
            var groupEntity = new Group()
            {
                Name = addGroupDto.Name,
            };

            await dbContext.Groups.AddAsync(groupEntity);
            await dbContext.SaveChangesAsync();

            return Ok(groupEntity);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateGroup(int id, UpdateGroupDto updateGroupDto)
        {
            var group = await dbContext.Groups.FindAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            group.Name = updateGroupDto.Name;

            await dbContext.SaveChangesAsync();

            return Ok(group);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var group = await dbContext.Groups.FindAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            dbContext.Groups.Remove(group);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
