using GraphQL.Types;
using SimpleCRM.Models;
using SimpleCRM.Repository;
using SimpleCRM.Types;
using SimpleCRM.Types.InputTypes;

namespace SimpleCRM.Graphql
{
    public class ApiMutation : ObjectGraphType
    {
        public ApiMutation(IDataRepository dataRepo)
        {
            Field<CustomerType>()
                .Name("addCustomer")
                .Argument<CustomerInputType>("customer", "the customer to add")
                .Resolve(ctx =>
                {
                    var customer = ctx.GetArgument<Customer>("customer");
                    return dataRepo.AddAsync(customer);
                });
        }
    }
}
