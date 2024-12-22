using MediatR;
using NTierArchitecture.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Product.RemoveProductById
{
    internal sealed class RemoveProductByIdCommandHandler : IRequestHandler<RemoveProductByIdCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProductByIdCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveProductByIdCommand request, CancellationToken cancellationToken)
        {
            NTierArchitecture.Entities.Models.Product product = await _productRepository.GetByIdAsync(p => p.Id == request.Id, cancellationToken);
            if(product == null)
            {
                throw new ArgumentException("Ürün bulunamadı");
            }
            _productRepository.Remove(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
