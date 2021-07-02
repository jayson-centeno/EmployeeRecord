namespace EmployeeRecord.Domain.Model
{
    public class CommandResult
    {
        public bool Successful { get; set; }
        public string SuccessfulMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
}
