using AutoMapper;
using HRSystem.Dtos;
using HRSystem.Infrastructure.Models;

namespace HRSystem.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Employee, EmployeeResponseDto>();
        }
    }
}