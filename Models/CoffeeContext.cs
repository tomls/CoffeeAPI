using Microsoft.EntityFrameworkCore;

namespace CoffeeApi.Models
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext(DbContextOptions<CoffeeContext> options)
            : base(options)
        {
        }

        public DbSet<CoffeeItem> CoffeeItems { get; set; }
    }
}