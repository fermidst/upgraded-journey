using System.Threading.Tasks;
using AutoMapper;
using HRSystem.Dtos;
using HRSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<EmployeeResponseDto> GetEmployee(long id)
        {
            var result = await _employeeService.GetEmployeeAsync(id);
            return _mapper.Map<EmployeeResponseDto>(result);
        }
        
        [HttpPut("{id}")]
        public async Task<EmployeeResponseDto> UpdateEmployee(long id, EmployeeRequestDto employee)
        {
            var result = await _employeeService.UpdateEmployeeAsync(id, employee);
            return _mapper.Map<EmployeeResponseDto>(result);
        }
        
        [HttpPost("")]
        public async Task<EmployeeResponseDto> CreateClient(EmployeeRequestDto employee)
        {
            var result = await _employeeService.CreateEmployeeAsync(employee);
            return _mapper.Map<EmployeeResponseDto>(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(long id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return new NoContentResult();
        }
        
        [HttpGet("/employees")]
        public Employees GetEmployees()
        {
            var result = _employeeService.GetEmployeesAsync();
            return new Employees
            {
                Result = _mapper.ProjectTo<EmployeeResponseDto>(result)
            };
        }
    }
}