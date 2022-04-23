using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.ModelTypeFluentAPIConfigurations
{
    class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder.HasKey(Pk => Pk.Id);
            builder.Property(Pk => Pk.Id)
                   .ValueGeneratedOnAdd();
            builder.Ignore(ItemNavPop => ItemNavPop.Map);
            //builder.Ignore(ItemNavProp => ItemNavProp.PathToImg);
            builder.Property(ItemFk => ItemFk.MapLevel)
                   .IsRequired(false);

            builder.Property(Item => Item.Position)
                   .HasConversion(Position => JsonSerializer.Serialize(Position, null),
                                  Position => JsonSerializer.Deserialize<Point>(Position, null));

            builder.HasOne(ItemNavProp => ItemNavProp.Map)
                   .WithMany(MapNavprop => MapNavprop.Items)
                   .HasForeignKey(ItemFk => ItemFk.MapLevel)
                   .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(ItemNavProp => ItemNavProp.Inventory)
                   .WithMany(InventoryNavProp => InventoryNavProp.Items)
                   .HasForeignKey(ItemFk => ItemFk.InventoryId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
