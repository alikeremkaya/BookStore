using HS14_MVCKitapEvi.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS14_MVCKitapEvi.Infrastructure.DataAccess.Interfaces
{
    public interface  IAsyncUpdatableRepository<TEntity>: IAsyncRepository where TEntity : BaseEntity
    {
        public  Task<TEntity> UpdateAsync(TEntity entity);
    }
}
