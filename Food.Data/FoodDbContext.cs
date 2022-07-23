using System.Runtime;
using Food.Core;
using Microsoft.EntityFrameworkCore;

namespace Food.Data
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        {
            
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        
        
    }
}   