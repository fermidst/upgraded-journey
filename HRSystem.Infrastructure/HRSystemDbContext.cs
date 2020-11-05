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
            modelBuilder.Entity<Position>(builder =>
            {
                builder.ToTable("Positions");
                builder.HasKey(p => p.Id);
            });
            modelBuilder.Entity<Department>(builder =>
            {
                builder.ToTable("Departments");
                builder.HasKey(d => d.Id);
            });
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        
        public DbSet<Department> Departments { get; set; }
    }
}