using System.Threading.Tasks;
using AutoMapper;
using HRSystem.Dtos;
using HRSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public async Task<DepartmentResponseDto> GetDepartment(long id)
        {
            var result = await _departmentService.GetDepartmentAsync(id);
            return _mapper.Map<DepartmentResponseDto>(result);
        }
        
        [HttpPut("{id}")]
        public async Task<DepartmentResponseDto> UpdateDepartment(long id, DepartmentRequestDto department)
        {
            var result = await _departmentService.UpdateDepartmentAsync(id, department);
            return _mapper.Map<DepartmentResponseDto>(result);
        }
        
        [HttpPost("")]
        public async Task<DepartmentResponseDto> CreateDepartment(DepartmentRequestDto department)
        {
            var result = await _departmentService.CreateDepartmentAsync(department);
            return _mapper.Map<DepartmentResponseDto>(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(long id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return new NoContentResult();
        }
        
        [HttpGet("/departments")]
        public Departments GetDepartments()
        {
            var result = _departmentService.GetDepartmentsAsync();
            return new Departments
            {
                Result = _mapper.ProjectTo<DepartmentResponseDto>(result)
            };
        }
    }
}