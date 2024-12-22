using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repository;

namespace NTierArchitecture.Business.Features.UserRoles.SetUserRole
{
    internal sealed class SetUserRoleCommandHandler : IRequestHandler<SetUserRoleCommand, Unit>
    {
        private readonly IUserRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetUserRoleCommandHandler(IUnitOfWork unitOfWork, IUserRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SetUserRoleCommand request, CancellationToken cancellationToken)
        {
            var checkIsRoleSetExists = await _roleRepository.AnyAsync
                (p => p.AppUserId == request.UserId && p.AppRoleId == request.RoleId, cancellationToken);
            if (checkIsRoleSetExists)
            {
                throw new ArgumentException("Kullanıcı bu role zaten sahip");
            }
            UserRole userRole = new()
            {
                AppRoleId = request.RoleId,
                AppUserId = request.UserId,
            };
            await _roleRepository.AddAsync(userRole, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }

}
