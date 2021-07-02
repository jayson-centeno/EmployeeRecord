using AutoMapper;
using EmployeeRecord.Api.ViewModel;
using EmployeeRecord.Domain.CQS.Command;
using EmployeeRecord.Domain.CQS.Query;
using EmployeeRecord.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EmployeeRecord.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public EmployeeController(ILogger<EmployeeController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Create an employee
        /// </summary>
        /// <param name="employee">Employee</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(NewEmployeeVM employee) 
        {
            var commandModel = mapper.Map<CreateEmployeeCommand>(employee);
            var result = await mediator.Send(commandModel);
            return Ok(result);
        }

        /// <summary>
        /// Get an employee
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [ProducesResponseType(typeof(EmployeesVM), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(GetEmployeesQueryVM query)
        {
            var queryRequest = mapper.Map<GetEmployeesQuery>(query);
            var result = await mediator.Send(queryRequest);
            var mappedData = mapper.Map<EmployeesVM>(result);
            return Ok(mappedData);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(EmployeesVM), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await mediator.Send(new GetEmployeesQuery() { 
                Id = Id
            });
            var mappedData = mapper.Map<EmployeesVM>(result);
            return Ok(mappedData);
        }

        /// <summary>
        /// Update an employee
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(EmployeeVM employee)
        {
            var commandModel = mapper.Map<UpdateEmployeeCommand>(employee);
            var result = await mediator.Send(commandModel);
            return Ok(result);
        }

        /// <summary>
        /// Delete an employee
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await mediator.Send(new DeleteEmployeeCommand() {
                Id = Id
            });
            return Ok(result);
        }

    }
}