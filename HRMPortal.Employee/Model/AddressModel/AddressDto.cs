using HRMPortal.Employee.Entity;

namespace HRMPortal.Employee.Model.AddressModel
{
    public class AddressDto : BaseEntity
    {
        public string SuiteNumber { get; set; }
        public string StreetLine { get; set; }
        public string LandMark { get; set; }
        public string Area { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
