using HS14_MVCKitapEvi.Domain.Core.Interfaces;
using HS14_MVCKitapEvi.Domain.Enums;
namespace HS14_MVCKitapEvi.Domain.Core.BaseEntities
{
    public class BaseEntity : IUpdatebleEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        // Yeni bir BaseEntity nesnesi oluşturulduğunda otomatik olarak yeni bir GUID değeri atanır.
        public string? UpdatedBy { get; set; }   
        //Varlığı son güncelleyen kullanıcının adını içeren bir dize.
       //Bu özellik nullable'dır, yani boş bırakılabilir.
        public DateTime? UpdatedDate { get; set; } 
        //Varlığın son güncellenme tarihini içeren bir DateTime değeri. Bu özellik de nullable'dır.
        public string CreatedBy { get; set; }
        // Varlığı oluşturan kullanıcının adını içeren bir dize.
        public DateTime CreatedDate { get; set; }
        //Varlığın oluşturulma tarihini içeren bir DateTime değeri.
        public Status Status { get; set; }
        //Varlığın mevcut durumunu temsil eden bir enum değeridir.
        //Bu, genellikle aktif, pasif gibi durumları belirtmek için kullanılır.

    }
}
