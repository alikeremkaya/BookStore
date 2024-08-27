using HS14_MVCKitapEvi.Domain.Core.Interfaces;
using HS14_MVCKitapEvi.Domain.Entities;
using HS14_MVCKitapEvi.Infrastructure.AppContext;
using HS14_MVCKitapEvi.Infrastructure.DataAccess.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;


namespace HS14_MVCKitapEvi.Infrastructure.Repositories.AdminRepositories;

public class AdminRepository : EFBaseRepository<Admin>, IAdminRepository
{
    // IAdminRepository arabirimini tanımlamak, AdminRepository sınıfının ne yapması gerektiğini soyutlaştırır.
    //Bu, AdminRepository sınıfının sadece bu işlevselliği gerçekleştirmek üzere odaklanmasına olanak tanır.

    public AdminRepository(AppDbContext context) : base(context)
    {

    }
    public Task<Admin?> GetByIdentityId(string identityId)
    {
        return _table.FirstOrDefaultAsync(x=>x.IdentityId == identityId);
    }
}


//GetByIdentityId metodu, bir Admin nesnesini belirli bir kimlik bilgisi(identityId) kullanarak arayan bir metoddur.
//Bu metod, Entity Framework Core'un FirstOrDefaultAsync metodunu kullanarak asenkron bir şekilde çalışır.
//Metodun amacı, belirtilen identityId'ye sahip ilk Admin nesnesini bulmak ve döndürmektir.
//Eğer belirtilen identityId'ye sahip bir Admin nesnesi bulunursa, bu nesne döndürülür; aksi takdirde, null döndürülür.


//Parametre: Metod, bir string tipinde identityId parametresi alır.
//Bu parametre, aranacak Admin nesnesinin benzersiz kimlik bilgisini temsil eder.

//İşlem: Metod, _table koleksiyonundaki Admin nesnelerini asenkron bir şekilde iter eder ve her bir nesnenin IdentityId özelliği belirtilen identityId'yle eşleşip eşleşmediğini kontrol eder.
//İlk eşleşme bulunurken, bu Admin nesnesi metod tarafından döndürülür.


//Döndürme: Eğer belirtilen identityId'ye sahip bir Admin nesnesi bulunursa, bu nesne Task<Admin?> tipinde bir Task nesnesi olarak döndürülür.
//Bu Task, Admin nesnesinin sonucunu içermektedir. Eğer hiçbir Admin nesnesi belirtilen identityId'ye uymuyorsa, null döndürülür.



//Bu metodun kullanımı, genellikle bir Admin nesnesinin belirli bir kimlik bilgisi üzerinden veritabanından alınması gereken durumlarda karşımıza çıkar.
//Örneğin, bir admin kullanıcısının oturum açma işlemi sırasında, kullanıcının kimlik bilgilerini kullanarak ilgili Admin nesnesini bulmak ve bu bilgiyi kullanarak kullanıcının yetkilerini doğrulamak gerekebilir.

//Ayrıca, metotun asenkron olması, özellikle büyük veri setlerinde veya ağ üzerinden veri çekme gibi uzun süren işlemlerde, uygulamanın yanıt verme hızını korumanıza yardımcı olur.
//Bu, kullanıcı deneyimini iyileştirmek için önemlidir.
