using AutoMapper;
using EmployeeRecord.Api.Mapper;
using EmployeeRecord.Domain.CQS.Command;
using EmployeeRecord.Domain.CQS.Handler.Command;
using EmployeeRecord.Entities;
using EmployeeRecord.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecord.UnitTest
{
    [TestFixture]
    public class EmployeeHandlerTests
    {
        [Test]    
        public async Task CreateEmployeeCommandHandler_Should_do_proper_workflow() 
        {
            var mocker = new AutoMocker();

            var mapperRMock = mocker.GetMock<IMapper>();
            var loggerMock = mocker.GetMock<ILogger<CreateEmployeeCommandHandler>>();
            var repoMock = mocker.GetMock<IAppRespository>();

            var handler = new CreateEmployeeCommandHandler(loggerMock.Object, repoMock.Object, mapperRMock.Object);
            var x = await handler.Handle(new CreateEmployeeCommand(), default);

            //something like:
            repoMock.Verify(x => x.AddAsync(It.IsAny<Employee>()), Times.Once());
        }

        [Test]
        public async Task UpdateEmployeeCommandHandler_Should_do_proper_workflow()
        {
            var mocker = new AutoMocker();

            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();

            var mapperRMock = mocker.GetMock<IMapper>();
            var loggerMock = mocker.GetMock<ILogger<UpdateEmployeeCommandHandler>>();
            var repoMock = mocker.GetMock<IAppRespository>();

            var handler = new UpdateEmployeeCommandHandler(loggerMock.Object, repoMock.Object, mapper);
            var x = await handler.Handle(new UpdateEmployeeCommand() { Id = 1 }, default);

            //something like:
            repoMock.Verify(x => x.UpdateAsync(It.IsAny<Employee>(), It.IsAny<int>()), Times.Once());
        }

        [Test]
        public async Task DeleteEmployeeCommandHandler_Should_do_proper_workflow()
        {
            var mocker = new AutoMocker();
            var loggerMock = mocker.GetMock<ILogger<DeleteEmployeeCommandHandler>>();
            var repoMock = mocker.GetMock<IAppRespository>();
            repoMock.Setup(x => x.GetAsync<Employee>(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

            var handler = new DeleteEmployeeCommandHandler(loggerMock.Object, repoMock.Object);
            var x = await handler.Handle(new DeleteEmployeeCommand() { Id = 1 }, default);

            //something like:
            repoMock.Verify(x => x.GetAsync<Employee>(It.IsAny<int>()), Times.Once());
            repoMock.Verify(x => x.DeleteAsync(It.IsAny<Employee>()), Times.Once());
        }
    }
}
