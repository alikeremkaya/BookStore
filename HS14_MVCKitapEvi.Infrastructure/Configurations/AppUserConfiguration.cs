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
    public class AppUserConfiguration:BaseUserConfiguration<ProfileUser>
    {
        public override void Configure(EntityTypeBuilder<ProfileUser> builder)
        {
            base.Configure(builder);
        }
    }
}
