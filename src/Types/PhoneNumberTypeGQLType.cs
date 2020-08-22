using GraphQL.Types;
using SimpleCRM.Models;

namespace SimpleCRM.Types
{
    public class PhoneNumberTypeGQLType : ObjectGraphType<PhoneType>
    {
        public PhoneNumberTypeGQLType()
        {
            Name = "PhoneType";

            Field(pt => pt.Id, type: typeof(IdGraphType));
            Field(pt => pt.Type);
        }
    }
}
