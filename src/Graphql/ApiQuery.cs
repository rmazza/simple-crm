using GraphQL.Types;
using SimpleCRM.Data;
using SimpleCRM.Models;
using SimpleCRM.Repository;
using SimpleCRM.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SimpleCRM.Graphql
{
    public class ApiQuery : ObjectGraphType
    {
        public ApiQuery(ICustomerRepository customerRepo)
        {
            Field<ListGraphType<CustomerType>, List<Customer>>()
                .Name("customers")
                .ResolveAsync(ctx =>
                {
                    return customerRepo.GetCustomersAsync();
                });
            //Field<ListGraphType<EmailAddressType>, List<EmailAddress>>()
            //    .Name("email")
            //    .Argument<IdGraphType>("id", "email id")
            //    .ResolveAsync(ctx =>
            //    {
            //        var id = ctx.GetArgument<Guid>("id");
            //        return customerRepo.get
            //    });
        }
    }
}
