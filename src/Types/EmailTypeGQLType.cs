using GraphQL.Types;
using SimpleCRM.Models;

namespace SimpleCRM.Types
{
    public class EmailTypeGQLType : ObjectGraphType<EmailType>
    {
        public EmailTypeGQLType()
        {
            Name = "EmailType";
            Field(et => et.EmailTypeId, type: typeof(IdGraphType)).Description("The id of the email type");
            Field(et => et.Type);
        }
    }
}
