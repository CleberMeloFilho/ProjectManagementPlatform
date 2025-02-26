using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using ProjectManagementPlatform.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagementPlatform.Application.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user != null)
            {
                user.Username = request.Username;
                user.PasswordHash = request.Password; // Em um cenário real, use um hash seguro (ex: BCrypt)
                user.RoleId = request.RoleId;

                _userRepository.UpdateAsync(user);
                await _userRepository.SaveChangesAsync(cancellationToken);
            }
        }
    }
}