using System.Linq;
using System.Threading.Tasks;
using HRSystem.Dtos;
using HRSystem.Infrastructure;
using HRSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHRSystemDbContext _dbContext;

        public EmployeeService(IHRSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> GetEmployeeAsync(long id)
        {
            return await _dbContext.Employees.SingleOrDefaultAsync(emp => emp.Id == id);
        }

        public async Task<Employee> UpdateEmployeeAsync(long id, EmployeeRequestDto employee)
        {
            var entity = await _dbContext.Employees.SingleOrDefaultAsync(e => e.Id == id);
            entity.FullName = employee.FullName;
            entity.Department = employee.Department;
            entity.PositionId = employee.PositionId;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> CreateEmployeeAsync(EmployeeRequestDto employee)
        {
            var entry = await _dbContext.Employees.AddAsync(new Employee
            {
                FullName = employee.FullName,
                Department = employee.Department,
                PositionId = employee.PositionId
            });
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task DeleteEmployeeAsync(long id)
        {
            var entity = await _dbContext.Employees.SingleOrDefaultAsync(e => e.Id == id);
            _dbContext.Employees.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Employee> GetEmployeesAsync()
        {
            return _dbContext.Employees;
        }
    }
}