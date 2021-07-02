using EmployeeRecord.Domain.Model;
using FluentValidation;
using MediatR;

namespace EmployeeRecord.Domain.CQS.Command
{
    public class DeleteEmployeeCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
    }

    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}