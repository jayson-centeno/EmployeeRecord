using EmployeeRecord.Domain.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRecord.Domain.CQS.Command
{
    public class CreateEmployeeCommand : IRequest<CommandResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }

    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}
