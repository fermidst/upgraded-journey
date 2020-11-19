using System;
using System.Linq;
using System.Threading.Tasks;
using Travel.Dtos;
using Travel.Infrastructure;
using Travel.Infrastructure.Models;

namespace Travel.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly ITravelDbContext _dbContext;

        public BuyerService(ITravelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Buyer> CreateBuyerAsync(BuyerRequestDto buyer)
        {
            if (buyer is null)
            {
                throw new ArgumentException("param is null", nameof(buyer));
            }
            var entry = await _dbContext.Buyers.AddAsync(new Buyer
            {
                FullName = buyer.FullName,
                TicketId = buyer.TicketId
            });
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public IQueryable<Buyer> GetBuyersAsync()
        {
            return _dbContext.Buyers;
        }
    }
}