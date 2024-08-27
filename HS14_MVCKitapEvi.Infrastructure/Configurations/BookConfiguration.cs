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
    public class BookConfiguration:AudiTableEntityConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasMaxLength(128);
            builder.Property(b => b.DateOfPublish).IsRequired();
            builder.Property(b => b.IsAvailable).IsRequired();
            base.Configure(builder);
        }
    }
}
