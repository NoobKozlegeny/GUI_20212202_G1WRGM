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
    class WorldBuildingElementEntityTypeConfiguration : IEntityTypeConfiguration<WorldBuildingElement>
    {
        Random r = new Random();

        public void Configure(EntityTypeBuilder<WorldBuildingElement> builder)
        {
            builder.ToTable("WorldBuildingElement");
            builder.HasKey(Pk => Pk.Id);
            builder.Property(Pk => Pk.Id)
                   .ValueGeneratedOnAdd();
            builder.Ignore(WorldBuildingElementNavProp => WorldBuildingElementNavProp.Map);
            //builder.Ignore(WorldBuildingElementNavProp => WorldBuildingElementNavProp.PathToImg);
            builder.Property(WorldBuildingElementFk => WorldBuildingElementFk.MapLevel)
                   .IsRequired(false);

            builder.Property(WorldBuildingElement => WorldBuildingElement.Area)
                   .HasConversion(Area => JsonSerializer.Serialize(Area, null),
                                  Area => JsonSerializer.Deserialize<Size>(Area, null));
            builder.Property(WorldBuildingElement => WorldBuildingElement.Position)
                   .HasConversion(Position => JsonSerializer.Serialize(Position, null),
                                  Position => JsonSerializer.Deserialize<Point>(Position, null));

           
            builder.HasOne(WorldBuildingElementNavProp => WorldBuildingElementNavProp.Map)
                   .WithMany(MapNavprop => MapNavprop.WorldElements)
                   .HasForeignKey(WorldBuildingElementFk => WorldBuildingElementFk.MapLevel)
                   .OnDelete(DeleteBehavior.SetNull);

            //Adding Youtube's elements
            ConfigureYoutubeLevel(builder);
        }

        public void ConfigureYoutubeLevel(EntityTypeBuilder<WorldBuildingElement> builder)
        {
            int XElement = 0;
            int randomResult;
            int id = 1;

            //Adding wall sprites
            for (int i = id; i < 3; i++)
            {
                builder.HasData(new WorldBuildingElement()
                {
                    PathToImg = new Uri(System.IO.Path.Combine("Assets", "Levels", "Youtube", "yt_platform-6.png"),
                        UriKind.RelativeOrAbsolute),
                    MapLevel = 1,
                    Position = new Point(0, 1016 - XElement), //1080 - 64 - 384 -> grid.ActualHeight - bottomFloor.Area.Height - wall.Area.Height
                    Name = "yt_platform-6",
                    Id = i,
                    Area = new Size(128, 384)
                });

                XElement += 384;
                id = i;
            }

            //Adding the bottom sprites
            XElement = 0;

            for (int i = id + 1; i < 32; i++)
            {
                randomResult = r.Next(1, 3);
                builder.HasData(new WorldBuildingElement()
                {
                    PathToImg = new Uri(System.IO.Path.Combine("Assets", "Levels", "Youtube", $"yt_platform-{randomResult}.png"),
                        UriKind.RelativeOrAbsolute),
                    MapLevel = 1,
                    Position = new Point(XElement, 1016), //1080 - 64 -> grid.ActualHeight - bottomFloor.Area.Height
                    Name = $"yt_platform-{randomResult}",
                    Id = i,
                    Area = new Size(128, 64)
                });

                XElement += 128;
                id = i;
            }

            //Above bottom sprites
            id++;
            randomResult = r.Next(4, 6);

            builder.HasData(new WorldBuildingElement()
            {
                PathToImg = new Uri(System.IO.Path.Combine("Assets", "Levels", "Youtube", $"yt_platform-{randomResult}.png"),
                        UriKind.RelativeOrAbsolute),
                MapLevel = 1,
                Position = new Point(1024, 1080 - 192),
                Name = $"yt_platform-{randomResult}",
                Id = id,
                Area = new Size(128, 128)
            });
        }
    }
}
