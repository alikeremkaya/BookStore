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
    public class AuthorConfiguration:AudiTableEntityConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(c=>c.Name).IsRequired().HasMaxLength(128);
            builder.Property(c=>c.BirthDate).IsRequired().HasMaxLength(128);
            base.Configure(builder);    
        }

    }
}
