using MediatR;

namespace NTierArchitecture.Entities.Events.Users
{
    public sealed class SendRegisterEmail : INotificationHandler<UserDomainEvent>
    {
        public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
        {
            //notification.AppUser.Id;
            return Task.CompletedTask;
        }
    }
}
