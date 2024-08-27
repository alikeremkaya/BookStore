using HS14_MVCKitapEvi.Domain.Entities;
using HS14_MVCKitapEvi.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS14_MVCKitapEvi.Infrastructure.Repositories
{
    public interface IPublisherRepository : IAsyncRepository, IAsyncInserttableRepository<Publisher>, IAsyncFindableRepository<Publisher>, IAsyncQueryableRepository<Publisher>, IAsyncUpdatableRepository<Publisher>, IAsyncDeletableRepository<Publisher>
    {
    }
}
