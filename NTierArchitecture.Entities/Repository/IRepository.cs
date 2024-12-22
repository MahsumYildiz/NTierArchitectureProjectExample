using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Entities.Repository
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Remove(T entity);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> expression ,CancellationToken cancellationToken);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        bool Any(Expression<Func<T, bool>> expression);

    }
}
