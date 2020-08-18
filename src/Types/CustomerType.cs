using GraphQL.Types;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SimpleCRM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SimpleCRM.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Name = "Customer";

            Field(c => c.CustomerId, type: typeof(IdGraphType)).Description("The id of the customer");
            Field(c => c.FirstName).Description("First name of the customer");
            Field(c => c.MiddleName).Description("Middle name of the customer");
            Field(c => c.LastName);
            Field(c => c.AddDate);
            Field(c => c.AddUser, type: typeof(IdGraphType));
            Field(c => c.ChangeDate, nullable: true);
            Field(c => c.ChangeUser, type: typeof(IdGraphType), nullable: true);
            Field<ListGraphType<EmailAddressType>, List<EmailAddress>>()
                .Name("emailAddr")
                .Resolve(ctx =>
                    {
                        return ctx.Source.EmailAddresses;
                    }
                );
        }
    }

    public class EmailAddressType : ObjectGraphType<EmailAddress>
    {
        public EmailAddressType()
        {
            Name = "Email";

            Field(e => e.EmailId, type: typeof(IdGraphType)).Description("The id of the email");
            Field(e => e.Email, nullable: true).Description("Email Address");

            
        }
    }
}
