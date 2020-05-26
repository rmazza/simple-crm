using GraphQL.Types;
using SimpleCRM.Models;

namespace SimpleCRM.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Name = "Customer";

            Field(c => c.CustomerId).Description("The id of the customer");
            Field(c => c.FirstName).Description("First name of the customer");
            Field(c => c.MiddleName).Description("Middle name of the customer");
            Field(c => c.LastName);
            Field(c => c.AddDate);
            Field(c => c.AddUser);
        }
    }
}
