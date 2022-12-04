using DemoApplication.ViewModels.Admin.SubNavbar.Admin;
using FluentValidation;

namespace DemoApplication.Validators.Admin.Subnavbar.Update
{
    public class UpdateViewModelValidator : AbstractValidator<UpdateViewModel>
    {
        public UpdateViewModelValidator()
        {
            RuleFor(sn => sn.Name)
                .NotNull()
                .WithMessage("Title can't be empty")
                .NotEmpty()
                .WithMessage("Title can't be empty")
                .MinimumLength(3)
                .WithMessage("Minimum length should be 10")
                .MaximumLength(10)
                .WithMessage("Maximum length should be 45");

            RuleFor(sn=>sn.Url)
                .NotNull()
                .WithMessage("Title can't be empty")
                .NotEmpty()
                .WithMessage("Title can't be empty")
                .MinimumLength(5)
                .WithMessage("Minimum length should be 10")
                .MaximumLength(30)
                .WithMessage("Maximum length should be 45");

            RuleFor(sn => sn.RowNumber)
                .NotNull()
                .WithMessage("Row number must be selected")
                .NotEmpty()
                .WithMessage("Row number must be selected");
        }
    }
}
