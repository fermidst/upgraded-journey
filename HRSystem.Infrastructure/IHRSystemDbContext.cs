using System.Threading;
using System.Threading.Tasks;
using HRSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Infrastructure
{
    public interface IHRSystemDbContext
    {
        DbSet<Employee> Employees { get; set; }
        
        DbSet<Position> Positions { get; set; }
        DbSet<Department> Departments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}