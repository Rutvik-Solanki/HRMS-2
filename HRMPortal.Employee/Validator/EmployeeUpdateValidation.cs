using FluentValidation;
using HRMPortal.Employee.Models;

namespace HRMPortal.Employee.Validation
{
    public class EmployeeUpdateValidation: AbstractValidator<EmployeeUpdateDto>
    {
        public EmployeeUpdateValidation()
        {
            RuleFor(e => e.EmployeeCode).NotEmpty().Length(1, 50);
            RuleFor(e => e.Password).NotEmpty().Length(8);
            RuleFor(e => e.FirstName).NotEmpty().Length(1, 30);
            RuleFor(e => e.MiddleName).Length(0, 30);
            RuleFor(e => e.LastName).NotEmpty().Length(1, 30);
            RuleFor(e => e.Gender).IsInEnum();
            RuleFor(e => e.PersonalEmail).NotEmpty().EmailAddress();
            RuleFor(e => e.BusinessEmail).NotEmpty().EmailAddress();
            RuleFor(e => e.MobileNumber).NotEmpty().Length(10,12);
            RuleFor(e => e.BusinessUnit).NotEmpty().Length(1, 50);
            RuleFor(e => e.Designation).IsInEnum();
            RuleFor(e => e.DateOfJoining).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));
            RuleFor(e => e.ConfirmationDate).NotEmpty().GreaterThanOrEqualTo(e => e.DateOfJoining);
            RuleFor(e => e.AppraisalDate).NotEmpty().GreaterThan(e => e.ConfirmationDate);
            RuleFor(e => e.TotalExprience).GreaterThanOrEqualTo(0);
           
            RuleFor(e => e.EmergencyNumber).Length(0, 10);
            RuleFor(e => e.BloodGroup).IsInEnum();
            RuleFor(e => e.UpdatedBy).NotEmpty();
            RuleFor(e => e.UpdatedAt).NotEmpty().LessThanOrEqualTo(DateTime.UtcNow);
        }
    }
}
