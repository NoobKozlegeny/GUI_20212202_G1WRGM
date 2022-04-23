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

            builder.Property(Item => Item.Size)
                   .HasConversion(Size => JsonSerializer.Serialize(Size, null),
                                  Size => JsonSerializer.Deserialize<Size>(Size, null));
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

            //Youtube items
            ConfigureYoutubeLevel(builder);
        }

        public void ConfigureYoutubeLevel(EntityTypeBuilder<Item> builder)
        {
            //List<Item> items = new List<Item>()
            //{
            //    new Weapon() { Name = "Super Shotgun", IsPickedUp = false, PathToImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "SuperShotgun.png"), UriKind.RelativeOrAbsolute) },
            //    new Weapon() { Name = "Chaingun", IsPickedUp = false, PathToImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "Chaingun.png"), UriKind.RelativeOrAbsolute) },
            //    new Weapon() { Name = "Chaingun", IsPickedUp = true, PathToImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "Chaingun.png"), UriKind.RelativeOrAbsolute) },
            //};

            //builder.HasData(new Weapon()
            //{
            //    Name = "Super Shotgun",
            //    IsPickedUp = false,
            //    PathToImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "SuperShotgun.png"), UriKind.RelativeOrAbsolute),
            //    AmmoAmount = 12,
            //    Damage = 2,
            //    Id = 1,
            //    InventoryId = 1,

            //});
        }
    }
}
