using System.Linq;
using System.Threading.Tasks;
using Travel.Dtos;
using Travel.Infrastructure.Models;

namespace Travel.Services
{
    public interface ITicketService
    {
        Task<Ticket> GetTicketAsync(long id);
        Task<Ticket> UpdateTicketAsync(long id, TicketRequestDto ticket);
        Task<Ticket> CreateTicketAsync(TicketRequestDto ticket);
        Task DeleteTicketAsync(long id);
        IQueryable<Ticket> GetTicketsAsync();
    }
}