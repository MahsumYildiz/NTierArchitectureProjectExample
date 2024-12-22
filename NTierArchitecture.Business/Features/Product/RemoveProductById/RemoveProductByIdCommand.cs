using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Product.RemoveProductById
{
    public sealed record RemoveProductByIdCommand(Guid Id):IRequest;
   
}
