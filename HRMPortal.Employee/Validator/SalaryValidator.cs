using FluentValidation;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model.SalaryModel;

namespace HRMPortal.Employee.Validator
{
    public class SalaryValidator : AbstractValidator<SalaryAddUpdateDto>
    {
        public SalaryValidator() 
        {
            RuleFor(s => s.UANNumber)
                .NotEmpty().WithMessage("UAN number is required.")
                .Length(12).WithMessage("UAN number should be 12 digits.");

            RuleFor(s => s.PFNumber)
                .NotEmpty().WithMessage("PF number is required.")
                .Length(10).WithMessage("PF number should be 10 digits.");

            RuleFor(s => s.ESICNumber)
                .NotEmpty().WithMessage("ESIC number is required.")
                .Length(17).WithMessage("ESIC number should be 17 digits.");

            RuleFor(s => s.BankDetailId)
                .NotEmpty().WithMessage("Bank detail ID is required.");

            /*RuleFor(x => x.CreatedBy)
                .GreaterThan(0).WithMessage("CreatedBy must be greater than 0.");

            RuleFor(x => x.UpdatedBy)
                .GreaterThan(0).WithMessage("UpdatedBy must be greater than 0.");

            RuleFor(x => x.CreatedAt)
                .NotEmpty().WithMessage("CreatedAt is required.");

            RuleFor(x => x.UpdatedAt)
                .NotEmpty().WithMessage("UpdatedAt is required.");*/

        }
    }
}
