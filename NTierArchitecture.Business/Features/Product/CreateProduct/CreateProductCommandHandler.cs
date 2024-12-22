using MediatR;
using NTierArchitecture.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NTierArchitecture.Business.Features.Product.CreateProduct
{
    public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,Unit>
    {
        IProductRepository _productRepository;
        IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
              _productRepository = productRepository;
              _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            
            bool isProductNameExist= await _productRepository.AnyAsync(p=>p.Name==request.Name,cancellationToken);
            if(isProductNameExist)
            {
                throw new ArgumentException("Bu ürün adı kullanılmış");
            }

            NTierArchitecture.Entities.Models.Product product = new()
            {
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                CategoryId = request.CategoryId
            };
            await _productRepository.AddAsync(product,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
