using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMPortal.Employee.Entity
{
    public class Address : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SuiteNumber { get; set; }
        public string StreetLine { get; set; }
        public string LandMark { get; set; }
        public string Area { get; set; }
        public int ZipCode { get; set; }
        public string  City { get; set; }
        public string StateCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
