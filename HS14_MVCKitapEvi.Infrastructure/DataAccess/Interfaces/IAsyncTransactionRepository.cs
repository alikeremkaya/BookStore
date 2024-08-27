using HS14_MVCKitapEvi.Domain.Core.BaseEntities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS14_MVCKitapEvi.Infrastructure.DataAccess.Interfaces
{
    public interface IAsyncTransactionRepository
    {
        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        public  Task<IExecutionStrategy> CreateExecutionStrategy();
    }
}
