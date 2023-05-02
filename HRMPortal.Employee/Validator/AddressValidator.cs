using FluentValidation;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model.AddressModel;

namespace HRMPortal.Employee.Validator
{
	public class AddressValidator : AbstractValidator<AddressDto>
	{
		public AddressValidator()
		{
			RuleFor(x => x.SuiteNumber)
			.NotEmpty().WithMessage("Suite number is required.")
			.MinimumLength(1).WithMessage("Suite number cannot exceed 1 characters.");

			RuleFor(x => x.StreetLine)
				.NotEmpty().WithMessage("Street line is required.")
				.MinimumLength(10).WithMessage("Street line cannot exceed 10 characters.");

			RuleFor(x => x.LandMark)
				.MinimumLength(10).WithMessage("Landmark cannot exceed 10 characters.");

			RuleFor(x => x.Area)
				.NotEmpty().WithMessage("Area is required.")
				.MinimumLength(10).WithMessage("Area cannot exceed 10 characters.");

			RuleFor(x => x.ZipCode)
				.NotEmpty().WithMessage("Zip code is required.")
				.Must(BeValidZipCode).WithMessage("Zip code is invalid.");

			RuleFor(x => x.City)
				.NotEmpty().WithMessage("City is required.")
				.MaximumLength(50).WithMessage("City cannot exceed 50 characters.");

			RuleFor(x => x.StateCode)
				.NotEmpty().WithMessage("State code is required.")
				.MinimumLength(1).WithMessage("State cannot exceed 1 characters. ")
				.MaximumLength(4).WithMessage("State cannot exceed 4 characters.");

			RuleFor(x => x.State)
				.NotEmpty().WithMessage("State is required.")
				.MaximumLength(25).WithMessage("State cannot exceed 50 characters.");

			RuleFor(x => x.Country)
				.NotEmpty().WithMessage("Country is required.")
				.MaximumLength(25).WithMessage("Country cannot exceed 50 characters.");
		}

		private bool BeValidZipCode(int zipCode)
		{
			string zipString = zipCode.ToString();

			if (zipString.Length != 6)
			{
				return false;
			}

			foreach (char c in zipString)
			{
				if (!char.IsDigit(c))
				{
					return false;
				}
			}

			return true;
		}

	}
}
