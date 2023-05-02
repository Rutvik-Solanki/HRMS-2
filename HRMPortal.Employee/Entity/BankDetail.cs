using HRMPortal.Employee.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace HRMPortal.Employee.Entity
{
    public class BankDetail: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Accounttype? Accounttype { get; set; }
        public string AccountName { get; set; }
        public double AccountNumber { get; set; }
        public string IFSCCode { get; set; }

        //ForeignKey
        public int EmployeeDetailId { get; set; }
        public EmployeeDetail EmployeeDetail { get; set; }
    }
}
