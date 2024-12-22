namespace NTierArchitecture.Entities.Repository
{
    public interface IUnitOfWork
    {
        Task<int>SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
