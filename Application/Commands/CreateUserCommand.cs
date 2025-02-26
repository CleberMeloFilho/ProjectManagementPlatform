using MediatR;

namespace ProjectManagementPlatform.Application.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}