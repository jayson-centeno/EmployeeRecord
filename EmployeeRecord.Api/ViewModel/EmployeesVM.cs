using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecord.Api.ViewModel
{
    public class EmployeesVM
    {
        public List<EmployeeVM> Items { get; set; } = new List<EmployeeVM>();
        public int Total { get; set; }
    }
}
