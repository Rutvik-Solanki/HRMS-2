using HRMPortal.Employee.Enums;

namespace HRMPortal.Employee.Models
{
    public class EmployeeAddDto
    {
        public string EmployeeCode { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PersonalEmail { get; set; }

        public string BusinessEmail { get; set; }

        public string MobileNumber { get; set; }
        public string BusinessUnit { get; set; }

        public Designation Designation { get; set; }

        public DateOnly DateOfJoining { get; set; }
        public DateOnly ConfirmationDate { get; set; }
        public DateOnly AppraisalDate { get; set; }

        //altum and previous
        public double TotalExprience { get; set; }

        public int? PermanentAddressId { get; set; }

        public int? PresentAddressId { get; set; }
        public string? EmergencyNumber { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
