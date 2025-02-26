using Microsoft.AspNetCore.Mvc;
using ProjectManagementPlatform.Application.Queries;
using MediatR;
using ProjectManagementPlatform.Application.Commands;
using Microsoft.AspNetCore.Authorization;

namespace ProjectManagementPlatform.WebMVC.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query);
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            if (ModelState.IsValid)
            {
                var token = await _mediator.Send(command);
                Response.Cookies.Append("AuthToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // Use apenas em HTTPS
                    SameSite = SameSiteMode.Strict
                });
                return RedirectToAction("Index", "Home");
            }
            return View(command);
        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthToken");
            return RedirectToAction("Login");
        }
    }
}