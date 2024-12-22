using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.DataAccess.Repositories;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repository;

internal sealed class CategoryRepository:Repository<Category>,ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext contxt):base(contxt)
    {
            
    }
}