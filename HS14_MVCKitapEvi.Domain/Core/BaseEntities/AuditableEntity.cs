using HS14_MVCKitapEvi.Domain.Core.Interfaces;
namespace HS14_MVCKitapEvi.Domain.Core.BaseEntities;
public class AuditableEntity : BaseEntity, IDeletebleEntity
//AuditableEntity, BaseEntity sınıfından türemiş ve IDeleteableEntity arayüzünü uygulayan bir sınıftır.
{
    public string? DeletedBy { get; set; }
    //Varlığı silen kullanıcının adını içeren bir dize.
    //Bu özellik nullable'dır, yani boş bırakılabilir.
    public DateTime? DeletedDate { get; set; }
    //Varlığın silinme tarihini içeren bir DateTime değeri. 
}
