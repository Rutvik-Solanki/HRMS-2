using FluentValidation;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model.PreviousExprience;

namespace HRMPortal.Employee.Validators
{
    public class PreviousExprienceValidator : AbstractValidator<PreviousExprienceAddDto>
    {
        public PreviousExprienceValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Designation).NotEmpty().MinimumLength(10);
            RuleFor(x => x.DateOfJoining).NotEmpty().LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));
            RuleFor(x=>x.DateOfRelieving).NotEmpty().GreaterThanOrEqualTo(x => x.DateOfJoining).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));
            RuleFor(x => x.TotalExprience)
             .NotEmpty()
             .GreaterThan(0);
            RuleFor(x => x.TotalExprience)
             .NotEmpty()
             .GreaterThan(0)
             .Must((previousExprience, totalExprience) =>
             {
                 var yearsOfExperience = previousExprience.DateOfRelieving.CompareTo(previousExprience.DateOfJoining);
                 Console.WriteLine($"TotalExprience :: {totalExprience}");
                 Console.WriteLine($"YearsOfExperience :: {yearsOfExperience}");
                 return totalExprience <= yearsOfExperience;
             })
             .WithMessage("Total experience cannot be greater than the duration of employment.");

        }
    }
}
