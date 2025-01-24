using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resturant.Management.System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Repository.Data.Configurations
{
    public class MenueItemConfiguration : IEntityTypeConfiguration<MenueItem>
    {
        public void Configure(EntityTypeBuilder<MenueItem> builder)
        {
            builder.Property(M => M.Cost).HasColumnType("decimal(18,2)");
            builder.Property(M => M.Price).HasColumnType("decimal(18,2)");
        }
    }
}
