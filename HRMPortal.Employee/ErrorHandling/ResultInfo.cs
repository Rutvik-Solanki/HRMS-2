namespace HRMPortal.Employee.ErrorHandling
{
    public class ResultInfo
    {
        public List<string> Messages { get; set; }
        public bool IsValid { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
}
