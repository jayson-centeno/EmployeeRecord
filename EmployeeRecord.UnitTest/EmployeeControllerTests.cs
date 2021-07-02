using AutoMapper;
using EmployeeRecord.Api.Controllers;
using EmployeeRecord.Domain.CQS.Command;
using EmployeeRecord.Domain.CQS.Query;
using EmployeeRecord.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeRecord.UnitTest
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        [Test]
        public async Task CreateEmployee_Should_do_proper_workflow() 
        {
            var mocker = new AutoMocker();
            
            var mapperRMock = mocker.GetMock<IMapper>();
            var loggerMock = mocker.GetMock<ILogger<EmployeeController>>();
            var midiatRMock = mocker.GetMock<IMediator>();

            midiatRMock.Setup(m => m.Send(It.IsAny<CreateEmployeeCommand>(), default))
                       .Returns(Task.FromResult(It.IsAny<CommandResult>()));

            var controller = new EmployeeController(loggerMock.Object, midiatRMock.Object, mapperRMock.Object);
            var result = await controller.Post(new Api.ViewModel.NewEmployeeVM() { });

            midiatRMock.Verify((m) => m.Send(It.IsAny<CreateEmployeeCommand>(), default), Times.Once);
        }

        [Test]
        public async Task UpdateEmployee_Should_do_proper_workflow()
        {
            var mocker = new AutoMocker();

            var mapperRMock = mocker.GetMock<IMapper>();
            var loggerMock = mocker.GetMock<ILogger<EmployeeController>>();
            var midiatRMock = mocker.GetMock<IMediator>();

            midiatRMock.Setup(m => m.Send(It.IsAny<UpdateEmployeeCommand>(), default))
                       .Returns(Task.FromResult(It.IsAny<CommandResult>()));

            var controller = new EmployeeController(loggerMock.Object, midiatRMock.Object, mapperRMock.Object);
            var result = await controller.Put(new Api.ViewModel.EmployeeVM());

            midiatRMock.Verify((m) => m.Send(It.IsAny<UpdateEmployeeCommand>(), default), Times.Once);
        }

        [Test]
        public async Task DeleteEmployee_Should_do_proper_workflow()
        {
            var mocker = new AutoMocker();

            var mapperRMock = mocker.GetMock<IMapper>();
            var loggerMock = mocker.GetMock<ILogger<EmployeeController>>();
            var midiatRMock = mocker.GetMock<IMediator>();

            midiatRMock.Setup(m => m.Send(It.IsAny<DeleteEmployeeCommand>(), default))
                       .Returns(Task.FromResult(It.IsAny<CommandResult>()));

            var controller = new EmployeeController(loggerMock.Object, midiatRMock.Object, mapperRMock.Object);
            var result = await controller.Delete(1);

            midiatRMock.Verify((m) => m.Send(It.IsAny<DeleteEmployeeCommand>(), default), Times.Once);
        }

        [Test]
        public async Task GetEmployee_Should_do_proper_workflow()
        {
            var mocker = new AutoMocker();

            var mapperRMock = mocker.GetMock<IMapper>();
            var loggerMock = mocker.GetMock<ILogger<EmployeeController>>();
            var midiatRMock = mocker.GetMock<IMediator>();

            midiatRMock.Setup(m => m.Send(It.IsAny<GetEmployeesQuery>(), default))
                       .Returns(Task.FromResult(It.IsAny<EmployeeResults>()));

            var controller = new EmployeeController(loggerMock.Object, midiatRMock.Object, mapperRMock.Object);
            var result = await controller.Get(1);

            midiatRMock.Verify((m) => m.Send(It.IsAny<GetEmployeesQuery>(), default), Times.Once);
        }
    }
}
