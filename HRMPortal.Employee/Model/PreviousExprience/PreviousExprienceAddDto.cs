using HRMPortal.Employee.Entity;

namespace HRMPortal.Employee.Model.PreviousExprience
{
    public class PreviousExprienceAddDto 
    {
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public DateOnly DateOfJoining { get; set; }
        public DateOnly DateOfRelieving { get; set; }
        public double TotalExprience { get; set; }
    }
}
