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
    class CollectibleEntityTypeConfiguration : IEntityTypeConfiguration<Collectible>
    {
        int id = 10;

        public void Configure(EntityTypeBuilder<Collectible> builder)
        {
            builder.HasBaseType<Item>();
            builder.Property(Collectible => Collectible.Position)
                   .HasConversion(Position => JsonSerializer.Serialize(Position, null),
                                  Position => JsonSerializer.Deserialize<Point>(Position, null));

            ConfigureYoutubeLevel(builder);
        }
        public void ConfigureYoutubeLevel(EntityTypeBuilder<Collectible> builder)
        {
            //Collectibles scattered on the ground, waiting for to be picked up
            CreateCollectible(builder, new Point(64, 448 - 112), "Comment.png", "Hello there Obi-wan", 1);
            CreateCollectible(builder, new Point(4096, 448 - 32), "Comment.png", "Hello there Obi-wan", 1);
        }

        public void CreateCollectible(EntityTypeBuilder<Collectible> builder, Point position, string collectibleImg, string description, int mapLevel)
        {
            builder.HasData(new Collectible()
            {
                Description = description,
                Id = id,
                //InventoryId = 1,
                IsPickedUp = false,
                MapLevel = mapLevel,
                Name = collectibleImg.Split('.')[0],
                PathToImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Collectibles", collectibleImg), UriKind.RelativeOrAbsolute),
                Position = position,
                Size = new Size(64, 64)
            });

            id++;
        }
    }
}
