using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRecord.Domain.Model
{
    public class EmployeeResults : CommandResult
    {
        public List<EmployeeResult> Items { get; set; } = new List<EmployeeResult>();
        public int Total { get; set; }
    }
}
