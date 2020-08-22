using GraphQL.Types;
using SimpleCRM.Models;

namespace SimpleCRM.Types
{
    public class EmailAddressType : ObjectGraphType<EmailAddress>
    {
        public EmailAddressType()
        {
            Name = "Email";

            Field(e => e.EmailId, type: typeof(IdGraphType)).Description("The id of the email");
            Field(e => e.Email, nullable: true).Description("Email Address");
            Field(e => e.EmailType.Type).Name("emailType");
        }
    }
}
