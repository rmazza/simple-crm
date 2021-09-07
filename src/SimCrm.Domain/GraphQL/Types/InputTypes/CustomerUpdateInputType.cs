using GraphQL.Types;
using SimCrm.Domain.Entities;

namespace SimCrm.Domain.GraphQL.Types.InputTypes
{
    public class CustomerUpdateInputType: InputObjectGraphType<Customer>
    {
        public CustomerUpdateInputType()
        {
            Name = "CustomerUpdateInput";

            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<DateGraphType>>("dateOfBirth");
            Field<StringGraphType>("middleName");
        }
    }
}
