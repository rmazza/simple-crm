using FluentValidation;
using SimCrm.Domain.Entities;

namespace SimCrm.Application.Validators
{
    public class EmailValidator : AbstractValidator<EmailAddress>
    {
        public EmailValidator()
        {
            RuleFor(emailAddress => emailAddress.HomeEmailAddress).EmailAddress();
        }
    }
}
