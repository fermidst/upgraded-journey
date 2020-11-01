using HRSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Infrastructure
{
    public class HRSystemDbContext : DbContext, IHRSystemDbContext
    {
        public HRSystemDbContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>(builder =>
            {
                builder.ToTable("Employees");
                builder.HasKey(e => e.Id);
            });
        }

        public DbSet<Employee> Employees { get; set; }
    }
}