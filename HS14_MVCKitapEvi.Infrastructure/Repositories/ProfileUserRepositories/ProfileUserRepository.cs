using HS14_MVCKitapEvi.Domain.Entities;
using HS14_MVCKitapEvi.Infrastructure.AppContext;
using HS14_MVCKitapEvi.Infrastructure.DataAccess.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS14_MVCKitapEvi.Infrastructure.Repositories.ProfileUserRepositories
{
    public class ProfileUserRepository : EFBaseRepository<ProfileUser>, IProfileUserRepository
    {
        public ProfileUserRepository(AppDbContext context) : base(context)
        {

        }

        public Task<ProfileUser?> GetByIdentityId(string identityId)
        {
            return _table.FirstOrDefaultAsync(x => x.IdentityId == identityId);
        }
    }
}
