using GraphQL.Types;
using SimpleCRM.Models;
using SimpleCRM.Repository;
using SimpleCRM.Types;
using System;
using System.Collections.Generic;

namespace SimpleCRM.Graphql
{
    public class ApiQuery : ObjectGraphType
    {
        public ApiQuery(IDataRepository dataRepo)
        {
            Field<ListGraphType<CustomerType>, List<Customer>>()
                .Name("customers")
                .ResolveAsync(ctx =>
                {
                    return dataRepo.GetCustomersAsync();
                });

            FieldAsync<CustomerType>(
                name: "customer",
                arguments: new QueryArguments(
                            new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: async (ctx) =>
                {
                    var id = ctx.GetArgument<string>("id");
                    return await dataRepo.GetCustomerAsync(Guid.Parse(id));
                });

            Field<ListGraphType<EmailTypeGQLType>, List<EmailType>>()
                .Name("emailTypes")
                .ResolveAsync(ctx =>
                {
                    return dataRepo.GetEmailTypes();
                });
        }
    }
}
