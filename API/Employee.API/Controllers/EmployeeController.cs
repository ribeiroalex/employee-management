using Employee.Domain.Commands;
using Employee.Domain.Handlers;
using Employee.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("v1/employees")]
    public class EmployeeController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<GenericCommandResult> Create([FromBody]CreateEmployeeCommand command,
            [FromServices] EmployeeHandler handler)
        {
            return (GenericCommandResult)(await handler.Handle(command));
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Domain.Entities.Employee> GetAll(
            [FromServices] IEmployeeRepository repository) => repository.GetAll();


        [HttpGet]
        [Route("id")]
        public async Task<Domain.Entities.Employee> GetById([FromRoute]Guid id,
            [FromServices] IEmployeeRepository repository) => (await repository.GetByIdAsync(id));

        [HttpPut]
        [Route("id")]
        public async Task<GenericCommandResult> Update([FromRoute] Guid id, [FromBody]UpdateEmployeeCommand command,
            [FromServices] EmployeeHandler handler)
        {
            return (GenericCommandResult)(await handler.Handle(command));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<GenericCommandResult> DeleteById([FromRoute] Guid id,
             [FromServices] EmployeeHandler handler) =>  (GenericCommandResult) await handler.Handle(new DeleteEmployeeCommandById(id));

    }
}
