using System.Linq;
using System.Threading.Tasks;
using Travel.Dtos;
using Travel.Infrastructure.Models;

namespace Travel.Services
{
    public interface IBuyerService
    {
        Task<Buyer> CreateBuyerAsync(BuyerRequestDto buyer);
        IQueryable<Buyer> GetBuyersAsync();
    }
}