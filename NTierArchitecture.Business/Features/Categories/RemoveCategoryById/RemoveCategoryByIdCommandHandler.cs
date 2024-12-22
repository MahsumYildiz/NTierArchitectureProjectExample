using MediatR;
using NTierArchitecture.Business.Features.Categories.RemoveCategory;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Categories.RemoveCategoryById
{
    internal sealed class RemoveCategoryByIdCommandHandler : IRequestHandler<RemoveCategoryByIdCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCategoryByIdCommandHandler(ICategoryRepository categoryRepository,IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAsync(p => p.Id == request.Id, cancellationToken);
            if (category == null) 
            {
                throw new ArgumentNullException("Kategori Bulunamadı");
            }
            _categoryRepository.Remove(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
