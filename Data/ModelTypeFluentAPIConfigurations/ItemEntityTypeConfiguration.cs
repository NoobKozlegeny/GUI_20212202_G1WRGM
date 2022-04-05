using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ModelTypeFluentAPIConfigurations
{
    class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder.HasKey(pk => pk.Id);
            builder.Property(pk => pk.Id).ValueGeneratedOnAdd();
            builder.Ignore(ItemNavPop => ItemNavPop.Map);

            builder.HasOne(ItemNavProp => ItemNavProp.Map)
                   .WithMany(MapNavprop => MapNavprop.Items)
                   .HasForeignKey(ItemFk => ItemFk.MapLevel)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
