using GraphQL.Types;
using SimpleCRM.Models;
using SimpleCRM.Repository;
using SimpleCRM.Types;
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
            Field<ListGraphType<EmailTypeGQLType>, List<EmailType>>()
                .Name("emailTypes")
                .ResolveAsync(ctx =>
                {
                    return dataRepo.GetEmailTypes();
                });
        }
    }
}
