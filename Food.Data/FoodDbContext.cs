using System.Runtime;
using Food.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Food.Data
{
    public class FoodDbContext : DbContext
    {
        // private readonly IConfiguration _configuration;

        // public FoodDbContext(IConfiguration configuration)
        // {
        //     _configuration = configuration;
        // }
        // public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        // {
        //     
        // }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer(@"Server=127.0.0.1;Database=Food;User Id=sa;Password=richie1234Jen!;");
        }
    }
}   