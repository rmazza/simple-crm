using GraphQL.Types;
using SimpleCRM.Repository;

namespace SimpleCRM.Graphql
{
    public class ApiMutation : ObjectGraphType
    {
        public ApiMutation(ICustomerRepository customerRepo)
        {
            //Field<CustomerType>()
            //    .Name("addCustomer")
            //    .ResolveAsync(ctx =>
            //    {
            //        var customer = ctx.GetArgument<Customer>("customer");
            //        customerRepo.AddCustomerAsync(customer);
            //    });
        }
    }
}
