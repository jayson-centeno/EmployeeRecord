using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRecord.Api.ViewModel
{
    public class GetEmployeesQueryVM
    {
        public int? Id { get; set; }
        public string Query { get; set; }

        public int? RowsPerPage { get; set; }
        public int? Page { get; set; }
        public string SortBy { get; set; }
        public bool? Descending { get; set; }
    }
}
