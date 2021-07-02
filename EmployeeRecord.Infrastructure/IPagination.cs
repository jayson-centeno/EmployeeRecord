using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRecord.Infrastructure
{
    public interface IPagination
    {
        int? RowsPerPage { get; set; }
        int? Page { get; set; }
        string SortBy { get; set; }
        bool? Descending { get; set; }
    }
}
