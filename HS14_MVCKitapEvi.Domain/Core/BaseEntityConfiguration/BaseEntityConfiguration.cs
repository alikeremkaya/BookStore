using HS14_MVCKitapEvi.Domain.Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace HS14_MVCKitapEvi.Domain.Core.BaseEntityConfiguration;
public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
       builder.HasKey(e => e.Id);
        //özelliğinin birincil anahtar (primary key) olarak belirlendiği ifade edilir.


        builder.Property(e=>e.Id).ValueGeneratedOnAdd();
        builder.Property(e=>e.CreatedBy).IsRequired();
        builder.Property(e=>e.CreatedDate).IsRequired();
        builder.Property(e=>e.Status).IsRequired();
        builder.Property(e=>e.UpdatedBy).IsRequired(false);
        builder.Property(e=>e.UpdatedDate).IsRequired(false);

    }
    //Entity Framework Core'un veri tabanı migration'larında
    //ve veri tabanı tablo oluşturma işlemlerinde kullanılacak olan kuralları belirler.
}
//Entity Framework Core'un veri tabanı migration'larında ve veri tabanı tablo oluşturma işlemlerinde kullanılacak olan kuralları belirler.
//Bu sayede, uygulama geliştiricileri veri tabanı şemasını doğrudan kod üzerinden yönetebilir ve veri bütünlüğünü koruyabilirler.


