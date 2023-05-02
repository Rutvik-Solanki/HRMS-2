using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMPortal.Employee.Entity
{
    public class Salary : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UANNumber { get; set; }
        public string PFNumber { get; set; }
        public string ESICNumber { get; set; }

		//ForeignKey
		public int BankDetailId { get; set; }
        public BankDetail BankDetail { get; set; }

		//ForeignKey
		public int EmployeeDetailId { get; set; }
        public EmployeeDetail EmployeeDetail { get; set; }

    }
}
