using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Auth.Register
{
    public sealed record RegisterCommand(
        String Name,
        String Lastname,
        String Email,
        String Username,
        String Password) :IRequest<Unit>;
}
