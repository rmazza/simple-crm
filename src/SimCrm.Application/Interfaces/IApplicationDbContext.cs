using Microsoft.EntityFrameworkCore;
using SimCrm.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SimCrm.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
