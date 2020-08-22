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
