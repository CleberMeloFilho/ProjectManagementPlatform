using MediatR;

namespace ProjectManagementPlatform.Application.Commands
{
    public class LoginCommand : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}