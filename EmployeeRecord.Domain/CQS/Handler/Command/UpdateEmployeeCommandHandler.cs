using AutoMapper;
using EmployeeRecord.Domain.CQS.Command;
using EmployeeRecord.Domain.Model;
using EmployeeRecord.Entities;
using EmployeeRecord.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeRecord.Domain.CQS.Handler.Command
{
    public class UpdateEmployeeCommandHandler :IRequestHandler<UpdateEmployeeCommand, CommandResult>
    {
        private readonly ILogger<UpdateEmployeeCommandHandler> _logger;
        private readonly IAppRespository appRespository;
        private readonly IMapper mapper;

        public UpdateEmployeeCommandHandler(ILogger<UpdateEmployeeCommandHandler> logger, IAppRespository appRespository, IMapper mapper)
        {
            this._logger = logger;
            this.appRespository = appRespository;
            this.mapper = mapper;
        }
        
        public async Task<CommandResult> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var commandResult = new CommandResult();

            try {
                var employeeUpdate = mapper.Map<Employee>(request);
                employeeUpdate = await appRespository.UpdateAsync(employeeUpdate, employeeUpdate.Id);
                commandResult.Successful = employeeUpdate != null;
            }
            catch (Exception e) {
                commandResult.ErrorMessage = e.Message;
                _logger.LogError(e.Message, e);
            }

            return commandResult;
        }
    }
}
