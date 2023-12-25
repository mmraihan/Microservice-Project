using Basket.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Basket.Api.Context
{
    public class BasketDbContext : DbContext
    {    
        public BasketDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ShoppingCartEntity> ShoppingCarts { get; set; }
        
    }
}
