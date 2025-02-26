using Microsoft.AspNetCore.Mvc;
using ProjectManagementPlatform.Application.Queries;
using MediatR;
using ProjectManagementPlatform.Application.Commands;
using Microsoft.AspNetCore.Authorization;

namespace ProjectManagementPlatform.WebMVC.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllProjectsQuery();
            var projects = await _mediator.Send(query);
            return View(projects);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var query = new GetProjectByIdQuery { Id = id };
            var project = await _mediator.Send(query);
            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateProjectCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var query = new GetProjectByIdQuery { Id = id };
            var project = await _mediator.Send(query);
            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var command = new DeleteProjectCommand { Id = id };
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ProgressReport()
        {
            var query = new GetProjectProgressQuery();
            var report = await _mediator.Send(query);
            return View(report);
        }
    }
}