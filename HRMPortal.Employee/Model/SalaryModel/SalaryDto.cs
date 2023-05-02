using HRMPortal.Employee.Entity;

namespace HRMPortal.Employee.Model.SalaryModel
{
    public class SalaryDto : BaseEntity
    {
        public int Id { get; set; }
        public string UANNumber { get; set; }
        public string PFNumber { get; set; }
        public string ESICNumber { get; set; }
        public int EmployeeDetailId { get; set; }        
        public int BankDetailId { get; set; }

    }
}
