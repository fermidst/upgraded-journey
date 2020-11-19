using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travel.Dtos;
using Travel.Infrastructure;
using Travel.Infrastructure.Models;

namespace Travel.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITravelDbContext _dbContext;

        public TicketService(ITravelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Ticket> GetTicketAsync(long id)
        {
            return await _dbContext.Tickets.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Ticket> UpdateTicketAsync(long id, TicketRequestDto ticket)
        {
            if (id < 0)
            {
                throw new ArgumentException("param is null", nameof(id));
            }
            if (ticket is null)
            {
                throw new ArgumentException("param is null", nameof(ticket));
            }
            var entity = await _dbContext.Tickets.SingleOrDefaultAsync(t => t.Id == id);
            entity.Name = ticket.Name;
            entity.Country = ticket.Country;
            entity.Price = ticket.Price;
            entity.StartDate = ticket.StartDate;
            entity.EndDate = ticket.EndDate;
            entity.OtherInfo = ticket.OtherInfo;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Ticket> CreateTicketAsync(TicketRequestDto ticket)
        {
            if (ticket is null)
            {
                throw new ArgumentException("param is null", nameof(ticket));
            }
            var entry = await _dbContext.Tickets.AddAsync(new Ticket
            {
                Name = ticket.Name,
                Country = ticket.Country,
                Price = ticket.Price,
                StartDate = ticket.StartDate,
                EndDate = ticket.EndDate,
                OtherInfo = ticket.OtherInfo
            });
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task DeleteTicketAsync(long id)
        {
            var entity = await _dbContext.Tickets.SingleOrDefaultAsync(t => t.Id == id);
            _dbContext.Tickets.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Ticket> GetTicketsAsync()
        {
            return _dbContext.Tickets;
        }
    }
}