using NTierArchitecture.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Features.Auth.Register;
using NTierArchitecture.Business.Features.Auth.Login;
using Microsoft.AspNetCore.Authorization;

namespace NTierArchitecture.WebApi.Controllers
{
    [AllowAnonymous]

    public sealed class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {

        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
        {
           var response=  await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
