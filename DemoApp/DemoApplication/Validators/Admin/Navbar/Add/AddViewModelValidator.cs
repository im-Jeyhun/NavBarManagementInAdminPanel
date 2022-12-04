using DemoApplication.ViewModels.Admin.Navbar.Admin;
using FluentValidation;

namespace DemoApplication.Validators.Admin.Navbar.Add
{
    public class AddViewModelValidator : AbstractValidator<AddViewModel>
    {
        public AddViewModelValidator()
        {
            RuleFor(n => n.Name)
                .NotNull()
                .WithMessage("Name can't be empty")
                .NotEmpty()
                .WithMessage("Name can't be empty")
                .MinimumLength(3)
                .WithMessage("Minimum length should be 3")
                .MaximumLength(10)
                .WithMessage("Maximum length should be 10");

            RuleFor(n=>n.Url)
                .NotNull()
                .WithMessage("Url can't be empty")
                .NotEmpty()
                .WithMessage("Url can't be empty")
                .MinimumLength(5)
                .WithMessage("Minimum length should be 3")
                .MaximumLength(30)
                .WithMessage("Maximum length should be 30");

            RuleFor(n => n.RowNumber)
                .NotNull()
                .WithMessage("Row number must be selected")
                .NotEmpty()
                .WithMessage("Row number must be selected");
        }
    }
}
