using DemoApplication.ViewModels.Admin.Navbar.Admin;
using FluentValidation;

namespace DemoApplication.Validators.Admin.Navbar.Update
{
    public class UpdateViewModelValidator : AbstractValidator<UpdateViewModel>
    {
        public UpdateViewModelValidator()
        {
            RuleFor(n => n.Name)
                .NotNull()
                .WithMessage("Title can't be empty")
                .NotEmpty()
                .WithMessage("Title can't be empty")
                .MinimumLength(3)
                .WithMessage("Minimum length should be 10")
                .MaximumLength(10)
                .WithMessage("Maximum length should be 45");

            RuleFor(n=>n.Url)
                .NotNull()
                .WithMessage("Title can't be empty")
                .NotEmpty()
                .WithMessage("Title can't be empty")
                .MinimumLength(5)
                .WithMessage("Minimum length should be 10")
                .MaximumLength(30)
                .WithMessage("Maximum length should be 45");

            RuleFor(n => n.RowNumber)
                .NotNull()
                .WithMessage("Row number must be selected")
                .NotEmpty()
                .WithMessage("Row number must be selected");
        }
    }
}
