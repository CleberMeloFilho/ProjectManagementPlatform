using MediatR;
using ProjectManagementPlatform.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagementPlatform.Application.Commands
{
    public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand>
    {
        private readonly IUserRepository _userRepository;

        public SendNotificationCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user != null)
            {
                // Simular o envio de uma notificação (ex: email, mensagem, etc.)
                // Aqui você pode integrar com um serviço de notificação real
                System.Diagnostics.Debug.WriteLine($"Notification sent to {user.Username}: {request.Message}");
            }
        }
    }
}