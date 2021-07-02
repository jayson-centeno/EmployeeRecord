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
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CommandResult>
    {
        private readonly ILogger<CreateEmployeeCommandHandler> _logger;
        private readonly IAppRespository appRespository;
        private readonly IMapper mapper;

        public CreateEmployeeCommandHandler(ILogger<CreateEmployeeCommandHandler> logger, IAppRespository appRespository, IMapper mapper)
        {
            this._logger = logger;
            this.appRespository = appRespository;
            this.mapper = mapper;
        }
        
        public async Task<CommandResult> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var commandResult = new CommandResult();

            try {
                var employeeEntity = mapper.Map<Employee>(request);
                var employee = await appRespository.AddAsync(employeeEntity);
                commandResult.Successful = employee != null;
            }
            catch (Exception e) {
                commandResult.ErrorMessage = e.Message;
                _logger.LogError(e.Message, e);
            }

            return commandResult;
        }
    }
}
