using HRMPortal.Employee.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestHRMS.Enums;

namespace HRMPortal.Employee.Entity
{
    public class Leave : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public int RequestId { get; set; }
        public Guid Guid { get; set; }
        public LeaveType LeaveTypes { get; set; }
        public LeaveDuration LeaveDuration { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }                        
        public int TotalDays { get; set; }
        public string Reason { get; set; }
        public LeaveStatus LeaveStatus { get; set; }

		//ForeignKey
		public int EmployeeDetailId { get; set; }
        public EmployeeDetail EmployeeDetail { get; set; }






    }
}
