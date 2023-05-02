using HRMPortal.Employee.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMPortal.Employee.Entity
{
    public class EducationDetail : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Certification Certification { get; set; }
        public string DegreeName { get; set; }
        public DateOnly YearOfPassing { get; set; }
        public string Score { get; set; }

		//ForeignKey
		public int EmployeeDetailId { get; set; }
        public EmployeeDetail EmployeeDetail { get; set; }



    }
}
