using GraphQL;
using SimpleCRM.Models;
using System;
using GraphQL.Types;

namespace SimpleCRM.Graphql
{
    public class ApiQuery : ObjectGraphType<object>
    {
        [GraphQLMetadata("customers")]
        public Customer GetCustomers()
        {
            return new Customer { CustomerId = Guid.NewGuid(), FirstName = "Bob" };
        }
    }
}
