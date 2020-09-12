using GraphQL.Types;
using SimpleCRM.Models;
using SimpleCRM.Repository;
using SimpleCRM.Types;
using SimpleCRM.Types.InputTypes;
using System;

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
            
            Field<CustomerType>()
                .Name("updateCustomer")
                .Argument<CustomerInputType>("customer", "the customer to update")
                .Resolve(ctx =>
                {
                    var customer = ctx.GetArgument<Customer>("customer");
                    return dataRepo.UpdateAsync(customer);
                });

            Field<CustomerType>()
                .Name("deleteCustomer")
                .Argument<IdGraphType>("id", "the id to delete")
                .Resolve(ctx =>
                {
                    var id = ctx.GetArgument<Guid>("id");
                    return dataRepo.DeleteAsync<Customer>(id);
                });
        }
    }
}
