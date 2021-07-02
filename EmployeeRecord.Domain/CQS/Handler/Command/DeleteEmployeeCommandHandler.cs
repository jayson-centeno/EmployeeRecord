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
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, CommandResult>
    {
        private readonly ILogger<DeleteEmployeeCommandHandler> _logger;
        private readonly IAppRespository appRespository;

        public DeleteEmployeeCommandHandler(ILogger<DeleteEmployeeCommandHandler> logger, IAppRespository appRespository)
        {
            this._logger = logger;
            this.appRespository = appRespository;
        }
        
        public async Task<CommandResult> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var commandResult = new CommandResult();
            try {
                var employee = await appRespository.GetAsync<Employee>(request.Id);
                if (employee != null) {
                    int result = await appRespository.DeleteAsync(employee);
                    commandResult.Successful = result > 0;
                }
            }
            catch (Exception e) {
                commandResult.ErrorMessage = e.Message;
                _logger.LogError(e.Message, e);
            }

            return commandResult;
        }
    }
}
