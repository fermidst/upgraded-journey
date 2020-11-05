using System.Linq;
using System.Threading.Tasks;
using HRSystem.Dtos;
using HRSystem.Infrastructure;
using HRSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IHRSystemDbContext _dbContext;

        public DepartmentService(IHRSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department> GetDepartmentAsync(long id)
        {
            return await _dbContext.Departments.SingleOrDefaultAsync(d => d.Id == id);

        }

        public async Task<Department> UpdateDepartmentAsync(long id, DepartmentRequestDto department)
        {
            var entity = await _dbContext.Departments.SingleOrDefaultAsync(d => d.Id == id);
            entity.Name = department.Name;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Department> CreateDepartmentAsync(DepartmentRequestDto department)
        {
            var entry = await _dbContext.Departments.AddAsync(new Department()
            {
                Name = department.Name,
            });
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task DeleteDepartmentAsync(long id)
        {
            var entity = await _dbContext.Departments.SingleOrDefaultAsync(d => d.Id == id);
            _dbContext.Departments.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Department> GetDepartmentsAsync()
        {
            return _dbContext.Departments;
        }
    }
}