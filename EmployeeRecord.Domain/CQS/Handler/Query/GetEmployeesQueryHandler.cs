using AutoMapper;
using EmployeeRecord.Domain.CQS.Query;
using EmployeeRecord.Domain.Model;
using EmployeeRecord.Entities;
using EmployeeRecord.Repository;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace EmployeeRecord.Domain.CQS.Handler.Command
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, EmployeeResults>
    {
        private readonly ILogger<GetEmployeesQueryHandler> _logger;
        private readonly IAppRespository appRespository;
        private readonly IMapper mapper;

        public GetEmployeesQueryHandler(ILogger<GetEmployeesQueryHandler> logger, IAppRespository appRespository, IMapper mapper)
        {
            this._logger = logger;
            this.appRespository = appRespository;
            this.mapper = mapper;
        }
        
        public async Task<EmployeeResults> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var commandResult = new EmployeeResults();

            if (!request.RowsPerPage.HasValue || 
                (request.RowsPerPage.HasValue && request.RowsPerPage.Value <= 0)) {
                request.RowsPerPage = 10;
            }

            if (!request.Page.HasValue || 
                (request.Page.HasValue && request.Page.Value <= 0)) {
                request.Page = 1;
            }

            int skip = request.RowsPerPage.GetValueOrDefault() * (request.Page.GetValueOrDefault() - 1);
            int take = request.RowsPerPage.GetValueOrDefault();
            if (request.RowsPerPage == -1) {
                take = 99999;
                skip = 0;
            }

            if (request.SortBy == null || request.SortBy == "ID")
                request.SortBy = "ID";

            try {

                int totalItems = 0;
                if (request.Id.HasValue && request.Id.Value > 0) {
                    var employee = await appRespository.GetAsync<Employee>(request.Id.Value);
                    var result = mapper.Map<EmployeeResult>(employee);
                    commandResult.Items.Add(result);
                    totalItems = 1;
                }
                else {
                    var query = appRespository.GetAll<Employee>();
                    totalItems = query.Count();

                    if (!string.IsNullOrEmpty(request.Query)) {
                        query = query.Where(employee => 
                                    employee.FirstName.Contains(request.Query) || 
                                    employee.FirstName.Contains(request.Query) || 
                                    employee.MiddleName.Contains(request.Query));
                    }

                    int totalFiltered = query.Count();
                    if (request.RowsPerPage == -1) {
                        take = totalItems;
                    }

                    var list = await query.Select(employee => new EmployeeResult {
                        Id = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        MiddleName = employee.MiddleName
                    })
                    .OrderBy(request.SortBy + (request.Descending == true ? " desc" : ""))
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

                    commandResult.Items.AddRange(list);
                }

                commandResult.Total = totalItems;
                commandResult.Successful = true;
            }
            catch (Exception e) {
                commandResult.ErrorMessage = e.Message;
                _logger.LogError(e.Message, e);
            }

            return commandResult;
        }
    }
}
