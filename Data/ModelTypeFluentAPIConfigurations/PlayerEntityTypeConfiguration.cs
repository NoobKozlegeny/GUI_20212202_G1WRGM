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
    class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasBaseType<Character>();

            //builder.Ignore(PlayerNavProp => PlayerNavProp.CanShoot);

            builder.Property(player => player.PathToImg)
                   .HasConversion(Image => JsonSerializer.Serialize(Image, null),
                                  Image => JsonSerializer.Deserialize<Uri>(Image, null));

            builder.HasOne(PlayerNavProp => PlayerNavProp.Inventory)
                   .WithOne(InventoryNavProp => InventoryNavProp.Player)
                   .HasForeignKey<Inventory>(PlayerFk => PlayerFk.PlayerId)
                   .OnDelete(DeleteBehavior.SetNull);

            //Youtube player
            ConfigureYoutubeLevel(builder);
        }

        public void ConfigureYoutubeLevel(EntityTypeBuilder<Player> builder)
        {
            //Player
            builder.HasData(new Player()
            {
                Name = "Player",
                PathToImg = new Uri(System.IO.Path.Combine("Assets", "Characters", "Players", "Chad.png"), UriKind.RelativeOrAbsolute),
                //Inventory = new Inventory(),
                Armour = 0,
                HealthPoints = 5,
                Speed = 1,
                MapLevel = 1,
                Position = new Point(128, 888 - 80),
                Size = new Size(128, 128),
                Id = 1,
            });
        }
    }
}
