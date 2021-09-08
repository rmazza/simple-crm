using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Simcrm.Domain.GraphQL.Types;
using SimCrm.Application.Interfaces;
using SimCrm.Domain.Entities;
using System.Collections.Generic;

namespace Simcrm.Application.GraphQL.Query
{
    public class ApiQuery : ObjectGraphType
    {
        public ApiQuery()
        {
            FieldAsync<ListGraphType<CustomerType>, IEnumerable<Customer>>(
                name: "customers",
                description: "Returns all customers",
                arguments: null,
                resolve: async ctx => await ctx.RequestServices.GetRequiredService<IApplicationDbContext>().Customers.ToListAsync());
        }
    }
}
