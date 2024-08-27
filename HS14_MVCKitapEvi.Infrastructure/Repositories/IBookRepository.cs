using HS14_MVCKitapEvi.Domain.Entities;
using HS14_MVCKitapEvi.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS14_MVCKitapEvi.Infrastructure.Repositories
{
    public interface IBookRepository : IAsyncRepository, IAsyncInserttableRepository<Book>, IAsyncFindableRepository<Book>, IAsyncQueryableRepository<Book>, IAsyncUpdatableRepository<Book>, IAsyncDeletableRepository<Book>
    {
    }
}
