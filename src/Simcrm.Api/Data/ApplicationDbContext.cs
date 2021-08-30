using Microsoft.EntityFrameworkCore;
using SimCrm.Domain.Entities;

namespace Simcrm.Api.Data
{
    public class ApplicationDbContext : DbContext//ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options) : base (options)
            //IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
