using EmployeeRecord.Domain;
using EmployeeRecord.Domain.Services;
using EmployeeRecord.Entities;
using EmployeeRecord.Infrastructure;
using EmployeeRecord.Repository;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace EmployeeRecord.Api
{
    public partial class Startup
    {
        public void ConfigureIOC(IServiceCollection services)
        {
            services.AddDbContext<EmployeeRecordDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default"), options => options.EnableRetryOnFailure())
                       .UseLazyLoadingProxies());

            services.AddScoped<IAppRespository>((serviceProvider) => 
                    new AppRepository(serviceProvider.GetService<EmployeeRecordDbContext>()));

            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAzureBlobService, AzureBlobService>();

            services.AddSingleton(Log.Logger);

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            services.AddValidatorsFromAssembly(Assembly.LoadFrom($"{path}\\EmployeeRecord.Domain.dll"));
            services.AddMediatR(Assembly.LoadFrom($"{path}\\EmployeeRecord.Domain.dll"));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }
    }
}
