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
    class BuffEntityTypeConfiguration : IEntityTypeConfiguration<Buff>
    {
        int id = 20;

        public void Configure(EntityTypeBuilder<Buff> builder)
        {
            builder.HasBaseType<Item>();
            builder.Property(Buff => Buff.Position)
                   .HasConversion(Position => JsonSerializer.Serialize(Position, null),
                                  Position => JsonSerializer.Deserialize<Point>(Position, null));

            ConfigureYoutubeLevel(builder);
        }
        public void ConfigureYoutubeLevel(EntityTypeBuilder<Buff> builder)
        {
            //Collectibles scattered on the ground, waiting for to be picked up
            CreateBuff(builder, new Point(768, 448 - 112), new Size(64, 64), "Protein.png", new TimeSpan(7000), BuffType.Damage, 1);
            CreateBuff(builder, new Point(3232, 448 - 32), new Size(64, 64), "Protein.png", new TimeSpan(7000), BuffType.Damage, 1);
        }

        public void CreateBuff(EntityTypeBuilder<Buff> builder, Point position, Size size, string buffImg, TimeSpan duration, BuffType affected, int mapLevel)
        {
            builder.HasData(new Buff()
            {
                Id = id,
                Duration = duration,
                Affected = affected,
                //InventoryId = 1,
                IsPickedUp = false,
                MapLevel = mapLevel,
                Name = buffImg.Split('.')[0],
                PathToImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Buffs", buffImg), UriKind.RelativeOrAbsolute),
                Position = position,
                Size = size
            });

            id++;
        }
    }
}
