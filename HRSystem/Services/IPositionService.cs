using System.Linq;
using System.Threading.Tasks;
using HRSystem.Dtos;
using HRSystem.Infrastructure.Models;

namespace HRSystem.Services
{
    public interface IPositionService
    {
        Task<Position> GetPositionAsync(long id);
        Task<Position> UpdatePositionAsync(long id, PositionRequestDto position);
        Task<Position> CreatePositionAsync(PositionRequestDto position);
        Task DeletePositionAsync(long id);
        IQueryable<Position> GetPositionsAsync();
    }
}