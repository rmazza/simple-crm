using GraphQL;
using GraphQL.Types;
using SimpleCRM.Models;

namespace SimpleCRM.Graphql
{
    [GraphQLMetadata("Mutation")]
    public class ApiMutation : ObjectGraphType
    {
        [GraphQLMetadata("addCustomer")]
        public Customer Add(Customer cst)
        {
            return null;
        }
    }
}
