,using HS14_MVCKitapEvi.Domain.Core.BaseEntities;

using System.Linq.Expressions;


namespace HS14_MVCKitapEvi.Infrastructure.DataAccess.Interfaces;

public interface IAsyncOrderableRepository<TEntity> where TEntity : BaseEntity
{
public Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> orderBy, bool orderByDesc, bool tracking = true);
public Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TKey>> orderBy, bool orderByDesc, bool tracking = true);

}
