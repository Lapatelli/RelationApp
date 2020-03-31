using FluentValidation;
using FluentValidation.Validators;
using RelationApp.Web.ViewModels;

namespace RelationApp.Web.Validation
{
    public class CreateRelationValidator : AbstractValidator<CreateRelationViewModel>
    {
        public CreateRelationValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name can't contain more than 100 letters");

            RuleFor(x => x.FullName)
                .MaximumLength(100).WithMessage("FullName can't contain more than 100 letters");

            RuleFor(x => x.TelephoneNumber)
                .MaximumLength(15).WithMessage("TelephoneNumber can't contain more than 15 symbols");

            RuleFor(x => x.EmailAddress)
                .EmailAddress(EmailValidationMode.Net4xRegex).WithMessage("Invalid e-mail address")
                .MaximumLength(50).WithMessage("Email length can't contain more than 15 symbols");

            RuleFor(x => x.Country)
                .MaximumLength(60).WithMessage("Name of the Country can't contain more than 60 letters");

            RuleFor(x => x.City)
                .MinimumLength(2).WithMessage("Name of the City can't contain less than 4 symbols")
                .MaximumLength(100).WithMessage("Name of the City can't contain more than 100 letters");

            RuleFor(x => x.Street)
                .MaximumLength(100).WithMessage("Name of the Street can't contain more than 100 letters");

            RuleFor(x => x.StreetNumber)
                .LessThan(1000000000).WithMessage("Street Number can't contain more than 9 digits");

            RuleFor(x => x.PostalCode)
                .MaximumLength(20).WithMessage("PostalCode can't contain more than 20 symbols");

        }
    }
}
