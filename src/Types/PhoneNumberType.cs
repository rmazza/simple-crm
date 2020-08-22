using GraphQL.Types;
using SimpleCRM.Models;

namespace SimpleCRM.Types
{
    public class PhoneNumberType : ObjectGraphType<PhoneNumber>
    {
        public PhoneNumberType()
        {
            Name = "Phone";

            Field(p => p.Id, type: typeof(IdGraphType)).Description("The id of the phone number");
            Field(p => p.Number);
            Field(p => p.Extension, nullable: true);
            //Field(p => p.Type);
        }
    }
}
