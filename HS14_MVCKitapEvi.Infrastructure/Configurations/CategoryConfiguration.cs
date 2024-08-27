using HS14_MVCKitapEvi.Domain.Core.BaseEntityConfiguration;
using HS14_MVCKitapEvi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS14_MVCKitapEvi.Infrastructure.Configurations
{
    public class CategoryConfiguration:AudiTableEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(128);
  
            base.Configure(builder);
        }
    }
}
