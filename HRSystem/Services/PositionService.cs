using System.Linq;
using System.Threading.Tasks;
using HRSystem.Dtos;
using HRSystem.Infrastructure;
using HRSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Services
{
    public class PositionService : IPositionService
    {
        private readonly IHRSystemDbContext _dbContext;

        public PositionService(IHRSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Position> GetPositionAsync(long id)
        {
            return await _dbContext.Positions.SingleOrDefaultAsync(p => p.Id == id);

        }

        public async Task<Position> UpdatePositionAsync(long id, PositionRequestDto position)
        {
            var entity = await _dbContext.Positions.SingleOrDefaultAsync(p => p.Id == id);
            entity.Name = position.Name;
            entity.Salary = position.Salary;
            entity.WorkingHoursPerWeek = position.WorkingHoursPerWeek;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Position> CreatePositionAsync(PositionRequestDto position)
        {
            var entry = await _dbContext.Positions.AddAsync(new Position
            {
                Name = position.Name,
                Salary = position.Salary,
                WorkingHoursPerWeek = position.WorkingHoursPerWeek
            });
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task DeletePositionAsync(long id)
        {
            var entity = await _dbContext.Positions.SingleOrDefaultAsync(p => p.Id == id);
            _dbContext.Positions.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Position> GetPositionsAsync()
        {
            return _dbContext.Positions;
        }
    }
}