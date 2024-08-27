using HS14_MVCKitapEvi.Domain.Core.BaseEntities;
namespace HS14_MVCKitapEvi.Infrastructure.DataAccess.Interfaces;
public interface IAsyncDeletableRepository<TEntity>: IAsyncRepository where TEntity : BaseEntity
{
    public Task DeleteAsync(TEntity entity);
    public Task DeleteRangeAsync(IEnumerable <TEntity> entities);


}
