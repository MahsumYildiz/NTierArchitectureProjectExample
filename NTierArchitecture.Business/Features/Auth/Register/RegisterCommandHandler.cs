﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using NTierArchitecture.Entities.Events.Users;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Features.Auth.Register
{
    internal sealed class RegisterCommandHandler:IRequestHandler<RegisterCommand,Unit>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMediator _mediator;


        public RegisterCommandHandler(UserManager<AppUser> userManager, IMediator mediator)
        {
             _userManager = userManager;
             _mediator = mediator;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var checkUserNameExists = await _userManager.FindByNameAsync(request.Username);
            if(checkUserNameExists is not null)
            {
                throw new ArgumentException("Bu kullanıcı adı daha önce kullanılmış");
            }
            var checkMailExists = await _userManager.FindByEmailAsync(request.Email);
            if(checkMailExists is not null)
            {
                throw new ArgumentException("Bu email daha önce kullanılmış");
            }
            AppUser appUser = new()
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Name = request.Name,
                LastName = request.Lastname,
                UserName = request.Username

            };
            await _userManager.CreateAsync(appUser,request.Password);
            await _mediator.Publish(new UserDomainEvent(appUser));
            return Unit.Value;


        }
    }
}
