using MediatR;
using NTierArchitecture.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NTierArchitecture.Business.Features.Product.UpdateProduct
{
    internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;   
        }
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            NTierArchitecture.Entities.Models.Product product = await _productRepository.GetByIdAsync(p=>p.Id==request.Id, cancellationToken);
            if(product is null)
            {
                throw new ArgumentException("Ürün bulunamadı");
            }
            if(product.Name!=request.Name)
            {
                bool isProductNameExists= await _productRepository.AnyAsync(p=>p.Name==request.Name, cancellationToken);
                if(isProductNameExists) 
                {
                    throw new ArgumentException("Bu ürün adı daha önce kullanılmış");
                }
            }
            product.Name = request.Name;
            product.Quantity = request.Quantity;
            product.CategoryId = request.CategoryId;
            product.Price = request.Price;
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
