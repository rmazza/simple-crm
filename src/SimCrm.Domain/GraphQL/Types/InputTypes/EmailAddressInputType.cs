using GraphQL.Types;
using SimCrm.Domain.Entities;
using SimCrm.Domain.Enumerations;

namespace SimCrm.Domain.GraphQL.Types.InputTypes
{
    public class EmailAddressInputType : InputObjectGraphType<EmailAddress>
    {
        public EmailAddressInputType()
        {
            Name = "EmailInput";

            Field<EnumerationGraphType<EmailType>>("type");
            Field<StringGraphType>("email");
        }
    }
}
