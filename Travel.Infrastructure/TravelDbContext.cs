using Microsoft.EntityFrameworkCore;
using Travel.Infrastructure.Models;

namespace Travel.Infrastructure
{
    public class TravelDbContext : DbContext, ITravelDbContext
    {
        public TravelDbContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        
    }
}