using HS14_MVCKitapEvi.Domain.Entities;
using HS14_MVCKitapEvi.Infrastructure.DataAccess.Interfaces;

namespace HS14_MVCKitapEvi.Infrastructure.Repositories.AdminRepositories;

public interface IAdminRepository :
                 IAsyncRepository,
                 IAsyncInserttableRepository<Admin>,
                 IAsyncFindableRepository<Admin>,
                 IAsyncQueryableRepository<Admin>,
                 IAsyncUpdatableRepository<Admin>,
                 IAsyncDeletableRepository<Admin>,

                 IAsyncTransactionRepository
{
    Task<Admin?> GetByIdentityId(string identityId);
}


//Veritabanı tablolarında, genellikle çeşitli türdeki veriler saklanır.
//Örneğin, bir e-ticaret uygulamasında ürün bilgileri, müşteri detayları, siparişler ve ödemeler gibi farklı tablolar olabilir.
//Her tablo, belirli bir konu hakkında bilgi içerir ve bu bilgiler arasında ilişkiler kurulabilir.
//Veritabanı tabloları, verileri organize etmek, saklamak ve yönetmek için kullanılır.
//Bu tablolar üzerinde insert (ekleme), find (ara), query (sorgu), update (güncelleme) ve delete (silme) gibi operasyonlar gerçekleştirilir.

//Insert: Yeni bir kayıt eklemek için kullanılır.
//Find: Belirli bir kriterlere uygun kayıtları bulmak için kullanılır.
//Query: Veritabanındaki verileri sorgulamak için kullanılır.Sorgular, genellikle belirli koşullara uyan verileri seçmek için kullanılır.
//Update: Mevcut kayıtları güncellemek için kullanılır.
//Delete: Belirli kriterlere uygun kayıtları silmek için kullanılır.
 

//Bu operasyonlar, veritabanı yönetim sistemlerinin (DBMS) sunduğu temel işlevlerdir ve uygulamaların veritabanı tablolarındaki verilere güvenli ve etkili bir şekilde erişmesini sağlar.
//Asenkron olarak bu operasyonları gerçekleştirmek, özellikle yüksek trafikli uygulamalarda, veritabanı işlemlerinin diğer uygulama işlemleri üzerinde beklenmeden gerçekleşmesini sağlar,
//bu da genel performansı ve kullanıcı deneyimini iyileştirir.
