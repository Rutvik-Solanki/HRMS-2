using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Enums;

namespace HRMPortal.Employee.Models
{
    public class EducationDetailDto : BaseEntity
    {
        public int EducationDetailId { get; set; }
        public Certification Certification { get; set; }
        public string DegreeName { get; set; }
        public DateOnly YearOfPassing { get; set; }
        public string Score { get; set; }

        public int EmployeeId { get; set; }
    }
}
