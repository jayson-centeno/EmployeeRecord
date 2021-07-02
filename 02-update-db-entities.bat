cd EmployeeRecord.Entities
dotnet ef dbcontext scaffold "Server=.;Database=EmployeeRecord;User ID=EmployeeRecord;Password=EmployeeRecord@123;" Microsoft.EntityFrameworkCore.SqlServer -f -p EmployeeRecord.Entities.csproj -c EmployeeRecordDbContext --use-database-names

pause