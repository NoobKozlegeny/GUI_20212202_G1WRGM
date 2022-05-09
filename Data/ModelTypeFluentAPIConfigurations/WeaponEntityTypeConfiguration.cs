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
    class WeaponEntityTypeConfiguration : IEntityTypeConfiguration<Weapon>
    {
        int id = 5;
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
            //Weapons scattered on the ground, waiting for to be picked up
            CreateWeapon(builder, new Point(128, 696 - 80), "SuperShotgun.png", 12, 2, 1);
            //CreateWeapon(builder, new Point(4224, 448), "Chaingun.png", 88, 1, 1);
        }

        public void CreateWeapon(EntityTypeBuilder<Weapon> builder, Point position, string weaponImg, int ammo, int damage, int mapLevel)
        {
            builder.HasData(new Weapon()
            {
                Name = weaponImg.Split('.')[0],
                IsPickedUp = false,
                PathToImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", weaponImg), UriKind.RelativeOrAbsolute),
                PathToBulletImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "bullet.png"), UriKind.RelativeOrAbsolute),
                AmmoAmount = ammo,
                Damage = damage,
                Id = 1,
                InventoryId = 1,
                MapLevel = mapLevel,
                Position = position,
                Size = new Size(128, 64)
            });

            id++;
        }
    }
}
