using System.Linq;
using System.Threading.Tasks;
using HRSystem.Dtos;
using HRSystem.Infrastructure.Models;

namespace HRSystem.Services
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentAsync(long id);
        Task<Department> UpdateDepartmentAsync(long id, DepartmentRequestDto department);
        Task<Department> CreateDepartmentAsync(DepartmentRequestDto department);
        Task DeleteDepartmentAsync(long id);
        IQueryable<Department> GetDepartmentsAsync();
    }
}