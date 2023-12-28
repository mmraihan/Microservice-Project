using Basket.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Basket.Api.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Style> Styles { get; set; }

    }
}
