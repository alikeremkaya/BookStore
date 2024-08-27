using HS14_MVCKitapEvi.Domain.Entities;
using HS14_MVCKitapEvi.Infrastructure.AppContext;
using HS14_MVCKitapEvi.Infrastructure.DataAccess.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS14_MVCKitapEvi.Infrastructure.Repositories
{
    public class CategoryRepository:EFBaseRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context):base(context) 
        {
        }
        
            
        
    }
}
