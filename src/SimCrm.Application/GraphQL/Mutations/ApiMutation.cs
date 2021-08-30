using GraphQL.Types;
using Simcrm.Domain.GraphQL.Types;
using GraphQL;
using SimCrm.Domain.GraphQL.Types.InputTypes;
using Microsoft.Extensions.DependencyInjection;
using SimCrm.Application.Interfaces;
using SimCrm.Domain.Entities;
using System;

namespace SimCrm.Application.GraphQL.Mutations
{
    public class ApiMutation : ObjectGraphType
    {
        public ApiMutation()
        {
            FieldAsync(
                typeof(CustomerType),
                "addCustomer",
                "The customer to add",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CustomerInputType>> { Name = "customer" }
                ),
                resolve: async context =>
                {
                    var dbContext = context.RequestServices.GetRequiredService<IApplicationDbContext>();
                    var customer = context.GetArgument<Customer>("customer");
                    var add = await dbContext.Customers.AddAsync(customer);
                    await dbContext.SaveChangesAsync();
                    return add.Entity;
                });
        }
    }
}
