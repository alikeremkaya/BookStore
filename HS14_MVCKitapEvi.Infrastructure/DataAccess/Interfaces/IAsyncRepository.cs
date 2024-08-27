using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS14_MVCKitapEvi.Infrastructure.DataAccess.Interfaces;

public interface IAsyncRepository
{
    public  Task<int> SaveChangesAsync();
}
