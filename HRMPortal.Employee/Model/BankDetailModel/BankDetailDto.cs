using AutoMapper;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Enums;


namespace HRMPortal.Employee.Models
{
    public class BankDetailDto : BaseEntity
    {
        public int BankDetailId { get; set; }
        public Accounttype Accounttype { get; set; }
        public string AccountName { get; set; }
        public double AccountNumber { get; set; }
        public string IFSCCode { get; set; }
     //   public int EmployeeId { get; set; }
    }
}
