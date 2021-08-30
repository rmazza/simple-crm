using GraphQL.Types;
using SimCrm.Domain.Entities;

namespace Simcrm.Domain.GraphQL.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Name = "Customer";

            Field(c => c.Id, type: typeof(IdGraphType)).Description("Id of the customer");
            Field(c => c.UserId, type: typeof(IntGraphType)).Description("Friendly user id");
            Field(c => c.FirstName).Description("First name of the customer");
            Field(c => c.MiddleName).Description("Middle name of the customer");
            Field(c => c.DateOfBirth, nullable: true);
            Field(c => c.LastName);
            Field(c => c.AddDate);
            Field(c => c.AddUser, type: typeof(IdGraphType));
            Field(c => c.ChangeDate, nullable: true);
            Field(c => c.ChangeUser, type: typeof(IdGraphType), nullable: true);

            //Field<ListGraphType<EmailAddressType>, List<EmailAddress>>()
            //    .Name("emailAddresses")
            //    .Resolve(ctx =>
            //    {
            //        return ctx.Source.EmailAddresses;
            //    }
            //    );
            //Field<ListGraphType<PhoneNumberType>, List<PhoneNumber>>()
            //    .Name("phoneNum")
            //    .Resolve(ctx =>
            //    {
            //        return ctx.Source.PhoneNumbers;
            //    });
        }
    }
}
