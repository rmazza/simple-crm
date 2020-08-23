using GraphQL.Types;
using SimpleCRM.Models;

namespace SimpleCRM.Types
{
    public class EmailTypeGQLType : ObjectGraphType<EmailType>
    {
        public EmailTypeGQLType()
        {
            Name = "EmailType";
            Field(et => et.Id, type: typeof(IdGraphType)).Description("The id of the email type");
            Field(et => et.Type);
        }
    }
}
