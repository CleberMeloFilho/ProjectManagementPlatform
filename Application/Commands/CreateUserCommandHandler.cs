using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using ProjectManagementPlatform.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagementPlatform.Application.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                PasswordHash = request.Password, // Em um cenário real, use um hash seguro (ex: BCrypt)
                RoleId = request.RoleId
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}