using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travel.Infrastructure.Models;

namespace Travel.Infrastructure
{
    public interface ITravelDbContext
    {
        DbSet<Ticket> Tickets { get; set; }
        DbSet<Buyer> Buyers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}