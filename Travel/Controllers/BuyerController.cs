using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Travel.Dtos;
using Travel.Services;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerService _buyerService;
        private readonly IMapper _mapper;

        public BuyerController(IBuyerService buyerService, IMapper mapper)
        {
            _buyerService = buyerService;
            _mapper = mapper;
        }
        
        [HttpPost("")]
        public async Task<BuyerResponseDto> CreateBuyer(BuyerRequestDto buyer)
        {
            var result = await _buyerService.CreateBuyerAsync(buyer);
            return _mapper.Map<BuyerResponseDto>(result);
        }

        [HttpGet("/api/buyers")]
        public Buyers GetBuyers()
        {
            var result = _buyerService.GetBuyersAsync();
            return new Buyers
            {
                Result = _mapper.ProjectTo<BuyerResponseDto>(result)
            };
        }
    }
}