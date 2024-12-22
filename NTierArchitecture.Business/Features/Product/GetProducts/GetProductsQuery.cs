using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTierArchitecture.Entities;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repository;
using Microsoft.EntityFrameworkCore;

namespace NTierArchitecture.Business.Features.Product.GetProducts
{
    public sealed record GetProductQuery(): IRequest<List<NTierArchitecture.Entities.Models.Product>>;
    internal sealed class GetProductsQueryHandler : IRequestHandler<GetProductQuery, List<NTierArchitecture.Entities.Models.Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;    

        }
        public async Task<List<Entities.Models.Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);
        }
    }
}
