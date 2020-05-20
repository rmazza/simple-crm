using GraphQL;
using Microsoft.Extensions.Logging;
using SimpleCRM.Data;
using SimpleCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SimpleCRM.Repository;

namespace SimpleCRM.Graphql
{
    public class Query
    {


        [GraphQLMetadata("customers")]
        public Customer GetCustomers()
        {
            return new Customer { CustomerId = Guid.NewGuid(), FirstName = "Bob" };
        }
    }
}
