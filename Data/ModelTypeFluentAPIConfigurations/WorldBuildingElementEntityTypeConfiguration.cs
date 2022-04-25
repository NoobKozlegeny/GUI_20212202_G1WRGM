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
        int id = 1;

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

            //Adding wall sprites on the left
            for (int i = id; i < 4; i++)
            {
                CreateWorldBuildingElement(builder, "yt_platform-6.png", new Point(0, 1016 - XElement), 1, new Size(128, 384));
                XElement += 384;
            }

            //Adding the bottom sprites
            XElement = 0;
            for (int i = id; i < 32; i++)
            {
                CreateWorldBuildingElement(builder, $"yt_platform-{r.Next(1, 3)}.png", new Point(XElement, 1016), 1, new Size(128, 64));
                XElement += 128;
            }

            //Above bottom sprites but not floating ones
            CreateWorldBuildingElement(builder, $"yt_platform-{r.Next(4, 6)}.png", new Point(896, 1080 - 192), 1, new Size(128, 128));
            CreateWorldBuildingElement(builder, "yt_platform-6.png", new Point(1280, 632), 1, new Size(128, 384));

            //Floating sprites
            XElement = 256;
            for (int i = id; i < 38; i++)
            {
                CreateWorldBuildingElement(builder, "yt_platform-3.png", new Point(XElement, 760), 1, new Size(128, 32));
                XElement += 128;
            }

            XElement = 640;
            while (id < 44)
            {
                if (XElement < 1152)
                {
                    CreateWorldBuildingElement(builder, "yt_platform-3.png", new Point(XElement, 512), 1, new Size(128, 32));
                }
                else if (XElement > 1408)
                {
                    CreateWorldBuildingElement(builder, "yt_platform-3.png", new Point(XElement, 512), 1, new Size(128, 32));
                }

                XElement += 128;
            }
        }

        public void CreateWorldBuildingElement(EntityTypeBuilder<WorldBuildingElement> builder, string WBEImg, Point position, int mapLevel, Size size)
        {
            builder.HasData(new WorldBuildingElement()
            {
                PathToImg = new Uri(System.IO.Path.Combine("Assets", "Levels", "Youtube", WBEImg),
                                    UriKind.RelativeOrAbsolute),
                MapLevel = mapLevel,
                Position = position,
                Name = WBEImg,
                Id = id,
                Area = size
            });

            id++;
        }
    }
}
