using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Travel.Dtos;
using Travel.Services;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public TicketController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public async Task<TicketResponseDto> GetTicket(long id)
        {
            var result = await _ticketService.GetTicketAsync(id);
            return _mapper.Map<TicketResponseDto>(result);
        }
        
        [HttpPut("{id}")]
        public async Task<TicketResponseDto> UpdateTicket(long id, TicketRequestDto ticket)
        {
            var result = await _ticketService.UpdateTicketAsync(id, ticket);
            return _mapper.Map<TicketResponseDto>(result);
        }
        
        [HttpPost("")]
        public async Task<TicketResponseDto> CreateTicket(TicketRequestDto ticket)
        {
            var result = await _ticketService.CreateTicketAsync(ticket);
            return _mapper.Map<TicketResponseDto>(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTicket(long id)
        {
            await _ticketService.DeleteTicketAsync(id);
            return new NoContentResult();
        }
        
        [HttpGet("/api/tickets")]
        public Tickets GetTickets()
        {
            var result = _ticketService.GetTicketsAsync();
            return new Tickets
            {
                Result = _mapper.ProjectTo<TicketResponseDto>(result)
            };
        }
    }
}