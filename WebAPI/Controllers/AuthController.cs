﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementPlatform.Application.Commands;
using System.Threading.Tasks;

namespace ProjectManagementPlatform.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(new { Token = token });
        }
    }
}