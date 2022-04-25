using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.ModelTypeFluentAPIConfigurations
{
    class WeaponEntityTypeConfiguration : IEntityTypeConfiguration<Weapon>
    {
        public void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.HasBaseType<Item>();
            builder.Property(Weapon => Weapon.FireRate)
                   .HasConversion(FireRate => JsonSerializer.Serialize(FireRate, null),
                                  FireRate => JsonSerializer.Deserialize<TimeSpan>(FireRate, null));

            //Youtube items
            ConfigureYoutubeLevel(builder);
        }

        public void ConfigureYoutubeLevel(EntityTypeBuilder<Weapon> builder)
        {
            int id = 1;
            //Weapons scattered on the ground, waiting for to be picked up
            builder.HasData(new Weapon()
            {
                Name = "Super Shotgun",
                IsPickedUp = false,
                PathToImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "SuperShotgun.png"), UriKind.RelativeOrAbsolute),
                AmmoAmount = 12,
                Damage = 2,
                Id = id,
                InventoryId = 1,
                MapLevel = 1,
                Position = new System.Drawing.Point(128, 696),
                Size = new System.Drawing.Size(128, 64)
            });

            id++;
            builder.HasData(new Weapon()
            {
                Name = "Chaingun",
                IsPickedUp = false,
                PathToImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "Chaingun.png"), UriKind.RelativeOrAbsolute),
                AmmoAmount = 88,
                Damage = 1,
                Id = id,
                //InventoryId = 1,
                MapLevel = 1,
                Position = new System.Drawing.Point(1024, 448),
                Size = new System.Drawing.Size(128, 64)
            });
            
        }
    }
}
