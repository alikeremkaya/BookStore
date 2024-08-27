using HS14_MVCKitapEvi.Domain.Core.BaseEntities;

using System.Linq.Expressions;


namespace HS14_MVCKitapEvi.Infrastructure.DataAccess.Interfaces
{
    public interface IAsyncQueryableRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true);
    }
}
