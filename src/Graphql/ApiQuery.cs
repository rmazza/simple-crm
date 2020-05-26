using GraphQL.Types;
using SimpleCRM.Data;
using SimpleCRM.Models;
using SimpleCRM.Repository;
using SimpleCRM.Types;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCRM.Graphql
{
    public class ApiQuery : ObjectGraphType
    {
        public ApiQuery(ICustomerRepository customerRepo)
        {
            Field<ListGraphType<CustomerType>, List<Customer>>()
                .Name("Customers")
                .ResolveAsync(ctx =>
                {
                    return customerRepo.GetCustomers();
                });
        }
    }
}
