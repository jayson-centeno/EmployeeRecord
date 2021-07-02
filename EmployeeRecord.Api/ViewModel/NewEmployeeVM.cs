using System.ComponentModel.DataAnnotations;

namespace EmployeeRecord.Api.ViewModel
{
    public class NewEmployeeVM
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
