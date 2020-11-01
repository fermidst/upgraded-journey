using System.Threading.Tasks;
using AutoMapper;
using HRSystem.Dtos;
using HRSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public PositionController(IPositionService positionService, IMapper mapper)
        {
            _positionService = positionService;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public async Task<PositionResponseDto> GetPosition(long id)
        {
            var result = await _positionService.GetPositionAsync(id);
            return _mapper.Map<PositionResponseDto>(result);
        }
        
        [HttpPut("{id}")]
        public async Task<PositionResponseDto> UpdatePosition(long id, PositionRequestDto position)
        {
            var result = await _positionService.UpdatePositionAsync(id, position);
            return _mapper.Map<PositionResponseDto>(result);
        }
        
        [HttpPost("")]
        public async Task<PositionResponseDto> CreatePosition(PositionRequestDto position)
        {
            var result = await _positionService.CreatePositionAsync(position);
            return _mapper.Map<PositionResponseDto>(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePosition(long id)
        {
            await _positionService.DeletePositionAsync(id);
            return new NoContentResult();
        }
        
        [HttpGet("/positions")]
        public Positions GetPositions()
        {
            var result = _positionService.GetPositionsAsync();
            return new Positions
            {
                Result = _mapper.ProjectTo<PositionResponseDto>(result)
            };
        }
    }
}