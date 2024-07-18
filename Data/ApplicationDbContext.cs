using Microsoft.EntityFrameworkCore;
using ZedERP.Models.Entities;

namespace ZedERP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
