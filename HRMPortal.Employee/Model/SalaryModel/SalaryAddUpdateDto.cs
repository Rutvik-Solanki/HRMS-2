using HRMPortal.Employee.Entity;

namespace HRMPortal.Employee.Model.SalaryModel
{
    public class SalaryAddUpdateDto : BaseEntity
    {
        public string UANNumber { get; set; }
        public string PFNumber { get; set; }
        public string ESICNumber { get; set; }
        public int BankDetailId { get; set; }
    }
}
