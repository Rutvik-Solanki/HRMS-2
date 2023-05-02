using HRMPortal.Employee.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMPortal.Employee.Entity
{
    public class LeaveBalance : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public LeaveType LeaveType { get; set; }
        public double TotalLeave { get; set; }

		//ForeignKey
		public int EmployeeDetailId { get; set; }
        public EmployeeDetail EmployeeDetail { get; set; }




    }
}
