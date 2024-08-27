using HS14_MVCKitapEvi.Domain.Core.BaseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace HS14_MVCKitapEvi.Domain.Core.BaseEntityConfiguration;

public class BaseUserConfiguration<TEntity> : AudiTableEntityConfiguration<TEntity> where TEntity : BaseUser
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.FirstName).IsRequired().HasMaxLength(128);
        builder.Property(e => e.LastName).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Email).IsRequired();
        base.Configure(builder);
  // çağrısıyla, temel sınıftaki yapılandırma ayarlarının da uygulanması sağlanır.
 // Bu, genellikle AudiTableEntityConfiguration<TEntity> sınıfında tanımlanan genel yapılandırma ayarlarını içerir.
    }
}
