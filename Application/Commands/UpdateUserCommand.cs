using MediatR;

namespace ProjectManagementPlatform.Application.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}