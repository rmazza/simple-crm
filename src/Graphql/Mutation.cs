using GraphQL;
using SimpleCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCRM.Graphql
{
    [GraphQLMetadata("Mutation")]
    public class Mutation
    {
        [GraphQLMetadata("addCustomer")]
        public Customer Add(Customer cst)
        {
            return null;
        }
    }
}
