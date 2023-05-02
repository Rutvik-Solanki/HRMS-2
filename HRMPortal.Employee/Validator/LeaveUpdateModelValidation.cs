using FluentValidation;
using HRMPortal.Employee.Models;

namespace HRMPortal.Employee.Validation
{
    public class LeaveUpdateModelValidation:AbstractValidator<LeaveUpdateModel>
    {
        public LeaveUpdateModelValidation()
        {
            RuleFor(x => x.RequestId)
             .NotEmpty()
             .WithMessage("The GUID field is required.");

            RuleFor(x => x.LeaveTypes)
                .NotNull()
                .WithMessage("The LeaveTypes field is required.");

            RuleFor(x => x.LeaveDuration)
                .NotNull()
                .WithMessage("The LeaveDuration field is require.");

            RuleFor(x => x.FromDate)
                .NotEmpty()
                .WithMessage("The FromDate field is required.")
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("The FromDate field must be greater than or equal to today.");

            RuleFor(x => x.ToDate)
                .NotEmpty()
                .WithMessage("The ToDate field is required.")
                .GreaterThanOrEqualTo(x => x.FromDate).LessThanOrEqualTo(x=>x.FromDate.AddDays(15))
                .WithMessage("The ToDate field must be greater than or equal to FromDate.");

            RuleFor(x => x.Reason)
                .MaximumLength(500)
                .WithMessage("The Reason field cannot be more than 500 characters.");

            RuleFor(x => x.UpdatedBy).NotEmpty();
            RuleFor(x => x.UpdatedAt).NotEmpty();
        }
  
    }
}
