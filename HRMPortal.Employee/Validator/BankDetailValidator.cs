using FluentValidation;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;

namespace HRMPortal.Employee.Validators
{
    public class BankDetailValidator : AbstractValidator<BankDetailDto>
    {
        public BankDetailValidator()
        {
            RuleFor(bankDetail => bankDetail.Accounttype).NotNull();
            RuleFor(bankDetail => bankDetail.AccountName).NotEmpty().MaximumLength(50);
            RuleFor(bankDetail => bankDetail.AccountNumber).NotEmpty().GreaterThan(0);
            RuleFor(bankDetail => bankDetail.IFSCCode).NotEmpty().Length(11);
            //RuleFor(bankDetail => bankDetail.EmployeeId).NotEmpty();
           // RuleFor(bankDetail => bankDetail.Employee).NotNull();
        }
    }
}
