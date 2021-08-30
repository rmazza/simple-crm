using Microsoft.EntityFrameworkCore;
using SimCrm.Application.Interfaces;
using SimCrm.Domain.Entities;

namespace Simcrm.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext//ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options) : base (options)
            //IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
