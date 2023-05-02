using HRMPortal.Employee.Entity;

namespace HRMPortal.Employee.Model.PreviousExprience
{
    public class PreviousExprienceUpdateDto : BaseEntity
    {
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public DateOnly DateOfJoining { get; set; }
        public DateOnly DateOfRelieving { get; set; }
        public double TotalExprience { get; set; }
        public int EmployeeId { get; set; }
    }
}
