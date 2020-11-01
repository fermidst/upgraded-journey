using System.Linq;
using System.Threading.Tasks;
using HRSystem.Dtos;
using HRSystem.Infrastructure.Models;

namespace HRSystem.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeAsync(long id);
        Task<Employee> UpdateEmployeeAsync(long id, EmployeeRequestDto employee);
        Task<Employee> CreateEmployeeAsync(EmployeeRequestDto employee);
        Task DeleteEmployeeAsync(long id);
        IQueryable<Employee> GetEmployeesAsync();
    }
}