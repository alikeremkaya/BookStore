using HS14_MVCKitapEvi.Domain.Entities;
using HS14_MVCKitapEvi.Infrastructure.AppContext;
using HS14_MVCKitapEvi.Infrastructure.DataAccess.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS14_MVCKitapEvi.Infrastructure.Repositories
{
    public class BookRepository : EFBaseRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
