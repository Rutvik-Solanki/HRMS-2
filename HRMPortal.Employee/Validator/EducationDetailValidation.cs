using FluentValidation;
using HRMPortal.Employee.Models;

namespace HRMPortal.Employee.Validators
{
    public class EducationDetailValidation : AbstractValidator<EducationDetailDto>
    {
        public EducationDetailValidation() 
        {
            //RuleFor(certification => certification.Certification).NotNull();
            //RuleFor(certification => certification.DegreeName).NotEmpty();
            //RuleFor(certification => certification.YearOfPassing).NotNull().LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now));
            //RuleFor(certification => certification.Score).NotEmpty().Matches(@"^\d+(\.\d{1,2})?$"); 
            //RuleFor(certification => certification.EmployeeId).NotNull().GreaterThan(0);

           
            RuleFor(x => x.EducationDetailId).NotEmpty();
            RuleFor(x => x.Certification).NotEmpty();
            RuleFor(x => x.DegreeName).NotEmpty().Length(1, 100);
            RuleFor(x => x.YearOfPassing).NotEmpty();
            RuleFor(x => x.Score).NotEmpty().Length(1, 20);
        }
    }
}
