using Microsoft.AspNetCore.Mvc;
using ProjectManagementPlatform.Application.Queries;
using MediatR;
using ProjectManagementPlatform.Application.Commands;
using Microsoft.AspNetCore.Authorization;

namespace ProjectManagementPlatform.WebMVC.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllTasksQuery();
            var tasks = await _mediator.Send(query);
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }
        [HttpPost("update-status")]
        public async Task<IActionResult> UpdateTaskStatus(UpdateTaskStatusCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }
    }
}