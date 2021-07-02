# EmployeeRecord
EmployeeRecord Using CQS, Fluent Validation, Repository Pattern and Unit Testing in .Net Core

**Setup:**
1. Attach SQL data - EmployeeRecord.bak 
2. Connection String is in appsettings.json
OR
3. Run dotnet-ef-cli-install.bat
4. init-database.sql - To Create the database and users
5. 01-syncdb.bat - To Generate the tables
6. 02-update-db-entities.bat - Create the entities
7. Open EmployeeRecordApi.sln
8. Run the application to open the swagger open api documentation
9. Test the Api using the UI

**Technologies**
1. Asp.Net Core API 3.1
2. EntityFramework Core 
3. Swagger Open API - https://swagger.io/
4. Automapper - https://automapper.org/
5. MediatR - https://github.com/jbogard/MediatR
6. CQS Design Pattern
7. DBUp - Database Migration
8. Repository Pattern
9. Unit Testing - Nunit, Mock-Automock
10. FluenValidation - https://fluentvalidation.net\
11. .Net Logging
