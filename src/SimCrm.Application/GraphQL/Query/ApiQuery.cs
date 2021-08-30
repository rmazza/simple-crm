using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Simcrm.Domain.GraphQL.Types;
using SimCrm.Application.Interfaces;
using SimCrm.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Simcrm.Application.GraphQL.Query
{
    public class ApiQuery : ObjectGraphType
    {
        public ApiQuery()
        {
            Field<ListGraphType<CustomerType>, IEnumerable<Customer>>()
                .Name("customers")
                .Resolve(ctx =>
                {
                    return ctx.RequestServices.GetRequiredService<IApplicationDbContext>().Customers.ToList();
                });
        }
    }
}
