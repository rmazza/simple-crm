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
        }
    }
}
