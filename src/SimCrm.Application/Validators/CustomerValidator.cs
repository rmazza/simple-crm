using FluentValidation;
using SimCrm.Domain.Entities;

namespace SimCrm.Application.Validators
{
    class CustomerValidator :  AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).NotEmpty();
            RuleFor(customer => customer.LastName).NotEmpty();
            RuleForEach(customer => customer.EmailAddresses).SetValidator(new EmailValidator());
        }
    }
}
