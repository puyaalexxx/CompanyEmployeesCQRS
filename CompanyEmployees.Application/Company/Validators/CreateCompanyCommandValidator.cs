using CompanyEmployees.Application.Company.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace CompanyEmployees.Application.Company.Validators
{
    public sealed class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(c => c.Company.Name)
                .NotEmpty()
                .MaximumLength(60)
                .NotNull()
                .WithMessage("Name must not be bigger than 60 characters.");

            RuleFor(c => c.Company.Address)
                .NotEmpty()
                .MaximumLength(60)
                .NotNull()
                .WithMessage("Address must not be bigger than 60 characters.");

        }

        /// <summary>
        /// Now, if we send a request with an empty request body, we are going to get the result produced from our action. 
        /// We can see the 400 status code and the error message.It is perfectly fine since we want to have a
        /// Bad Request response if the object sent from the client is null. But if, for any reason, you want to remove 
        /// that validation from the action and handle it with fluent validation rules, add this method
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override ValidationResult Validate(ValidationContext<CreateCompanyCommand> context)
        {
            return context.InstanceToValidate.Company is null
                ? new ValidationResult(new[] { new ValidationFailure("CompanyForCreationDto",
            "CompanyForCreationDto object is null") })
                : base.Validate(context);
        }
    }
}
