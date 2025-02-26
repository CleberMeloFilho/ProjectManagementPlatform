using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementPlatform.Application.Commands;
using ProjectManagementPlatform.Application.Queries;
using System.Threading.Tasks;

namespace ProjectManagementPlatform.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectCommand command)
        {
            var projectId = await _mediator.Send(command);
            return Ok(projectId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var query = new GetProjectByIdQuery { Id = id };
            var project = await _mediator.Send(query);
            return Ok(project);
        }
    }
}