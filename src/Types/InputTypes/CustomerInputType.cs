using GraphQL.Types;
using SimpleCRM.Models;

namespace SimpleCRM.Types.InputTypes
{
    public class CustomerInputType : InputObjectGraphType<Customer>
    {
        public CustomerInputType()
        {
            Name = "CustomerInput";

            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<DateGraphType>("dateOfBirth");
            Field<StringGraphType>("middleName");
        }
    }
}
