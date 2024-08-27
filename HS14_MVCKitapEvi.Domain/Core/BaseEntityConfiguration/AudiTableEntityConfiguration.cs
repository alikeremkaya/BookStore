using HS14_MVCKitapEvi.Domain.Core.BaseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HS14_MVCKitapEvi.Domain.Core.BaseEntityConfiguration
{
    public class AudiTableEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity> where TEntity : AuditableEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.DeletedBy).IsRequired(false);
            builder.Property(e => e.DeletedDate).IsRequired(false); 
            base.Configure(builder);
        }
    }
}
