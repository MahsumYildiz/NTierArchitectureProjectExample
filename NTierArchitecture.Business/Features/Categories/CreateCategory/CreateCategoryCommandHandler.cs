using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repository;

namespace NTierArchitecture.Business.Features.Categories.CreateCategory
{
    internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommands>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository,IUnitOfWork unitOfWork)
    {
        _categoryRepository= categoryRepository;
        _unitOfWork= unitOfWork;
    }
    public async Task Handle(CreateCategoryCommands request, CancellationToken cancellationToken)
    {

            var isCategoryNameExists = await _categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
            if(isCategoryNameExists)
            {
                throw new ArgumentException("Bu kategori daha önce oluşturulmuş!");
            }

            Category category = new()
            {
                Name = request.Name,
            };

            await _categoryRepository.AddAsync(category, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
}
