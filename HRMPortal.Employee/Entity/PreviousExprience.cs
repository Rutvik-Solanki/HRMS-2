using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMPortal.Employee.Entity
{
    public class PreviousExprience : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CompanyName { get; set; } 
        public string Designation { get; set;}
        public DateOnly DateOfJoining { get; set; }
        public DateOnly DateOfRelieving { get; set; }
        public double TotalExprience { get; set; }

		//ForeignKey
		public int EmployeeDetailId { get; set; }
        public EmployeeDetail EmployeeDetail { get; set; }



    }
}
