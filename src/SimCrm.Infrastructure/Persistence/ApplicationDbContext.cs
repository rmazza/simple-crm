using Microsoft.EntityFrameworkCore;
using SimCrm.Application.Interfaces;
using SimCrm.Domain.Entities;

namespace Simcrm.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext//ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options) : base (options)
            //IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
    }
}
