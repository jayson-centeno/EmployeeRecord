using EmployeeRecord.Domain.Model;
using EmployeeRecord.Infrastructure;
using MediatR;

namespace EmployeeRecord.Domain.CQS.Query
{
    public class GetEmployeesQuery : IRequest<EmployeeResults>, IPagination
    {
        public int? Id { get; set; }
        public string Query { get; set; }

        public int? RowsPerPage { get; set; }
        public int? Page { get; set; }
        public string SortBy { get; set; }
        public bool? Descending { get; set; }
    }
}