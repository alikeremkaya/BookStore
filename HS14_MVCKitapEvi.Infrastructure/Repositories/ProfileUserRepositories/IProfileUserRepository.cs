using HS14_MVCKitapEvi.Domain.Entities;
using HS14_MVCKitapEvi.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS14_MVCKitapEvi.Infrastructure.Repositories.ProfileUserRepositories
{
    public interface IProfileUserRepository : IAsyncRepository, IAsyncInserttableRepository<ProfileUser>, IAsyncFindableRepository<ProfileUser>, IAsyncQueryableRepository<ProfileUser>, IAsyncUpdatableRepository<ProfileUser>, IAsyncDeletableRepository<ProfileUser>, IAsyncTransactionRepository
    {
        Task<ProfileUser?> GetByIdentityId(string identityId);
    }
}
