using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementPlatform.Application.Commands;
using ProjectManagementPlatform.Application.Queries;
using System.Threading.Tasks;

namespace ProjectManagementPlatform.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> CreateTask(CreateTaskCommand command)
        {
            var taskId = await _mediator.Send(command);
            return Ok(taskId);
        }

        [HttpGet("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> GetTask(int id)
        {
            var query = new GetTaskByIdQuery { Id = id };
            var task = await _mediator.Send(query);
            return Ok(task);
        }

        [HttpPost("assign")]
        [Authorize(Policy = "ManagerOnly")]
        public async System.Threading.Tasks.Task<IActionResult> AssignTask(AssignTaskCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        
    }
}