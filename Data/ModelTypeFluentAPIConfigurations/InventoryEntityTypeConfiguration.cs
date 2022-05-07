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
    class InventoryEntityTypeConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(Pk => Pk.Id);
            builder.Ignore(Inventory => Inventory.SelectedItem);
            //builder.Ignore(Inventory => Inventory.PathToSelectedItemImg);

            builder.HasOne(InventoryNavProp => InventoryNavProp.Player)
                   .WithOne(PlayerNavProp => PlayerNavProp.Inventory)
                   .HasForeignKey<Inventory>(InventoryFk => InventoryFk.PlayerId)
                   .OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(InventoryNavProp => InventoryNavProp.Items)
                   .WithOne(ItemNavProp => ItemNavProp.Inventory)
                   .HasForeignKey(ItemFk => ItemFk.InventoryId)
                   .OnDelete(DeleteBehavior.SetNull);

            //Youtube inventory
            ConfigureYoutubeLevel(builder);
        }

        public void ConfigureYoutubeLevel(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasData(new Inventory()
            {
                PathToSelectedItemImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "SuperShotgun.png"), UriKind.RelativeOrAbsolute),
                Id = 1,
                PlayerId = 1,
                SelectedItemId = 1
            });
        }
    }
}
