using Microsoft.AspNetCore.Mvc;
using ProjectManagementPlatform.Application.Commands;
using MediatR;
using System.Threading.Tasks;

namespace ProjectManagementPlatform.WebMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            if (ModelState.IsValid)
            {
                var token = await _mediator.Send(command);
                // Armazenar o token em um cookie ou session
                return RedirectToAction("Index", "Home");
            }
            return View(command);
        }

        public IActionResult Logout()
        {
            // Remover o token do cookie ou session
            return RedirectToAction("Login");
        }
    }
}