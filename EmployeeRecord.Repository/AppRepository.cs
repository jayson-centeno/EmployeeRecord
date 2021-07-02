using Microsoft.EntityFrameworkCore;

namespace EmployeeRecord.Repository
{
    public class AppRepository : GenericRepository, IAppRespository
    {
        public AppRepository(DbContext context) : base(context)
        {
        }
    }
}