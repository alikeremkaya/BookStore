using HS14_MVCKitapEvi.Domain.Core.BaseEntities;


namespace HS14_MVCKitapEvi.Infrastructure.DataAccess.Interfaces
{
    public interface IAsyncInserttableRepository<TEntity>: IAsyncRepository where TEntity : BaseEntity
    {
        public Task<TEntity> AddAsync(TEntity entity);
        public Task AddRangeAsync(IEnumerable<TEntity> entities);

    }
}
