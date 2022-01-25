using System.Threading.Tasks;
using CQRS.API.Commands;
using CQRS.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            var response = await _mediator.Send(new GetTodoById.Query(id));

            return response == null ? NotFound() : Ok(response);
        }
        
        [HttpPost("")]
        public async Task<IActionResult> AddTodo(AddTodo.Command command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}