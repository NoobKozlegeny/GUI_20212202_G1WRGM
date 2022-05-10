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
            int YElement = 0;
            int randomResult;

            //Adding wall sprites on the left
            for (int i = id; i < 4; i++)
            {
                CreateWorldBuildingElement(builder, "yt_platform-6.png", new Point(0, 1016 - YElement), 1, new Size(128, 384));
                YElement += 384;
            }

            //Adding the bottom sprites
            XElement = 0;
            for (int i = id; i < 68; i++)
            {
                if (i != 29)
                {
                    CreateWorldBuildingElement(builder, $"yt_platform-{r.Next(1, 3)}.png", new Point(XElement, 1016), 1, new Size(128, 64));
                }
                XElement += 128;
            }

            //Above bottom sprites but not floating ones
            //CreateWorldBuildingElement(builder, $"yt_platform-{r.Next(4, 6)}.png", new Point(960, 1080 - 192 - 80), 1, new Size(128, 128));
            //CreateWorldBuildingElement(builder, "yt_platform-6.png", new Point(1280, 632 - 80), 1, new Size(128, 384));
            CreateWorldBuildingElement(builder, $"yt_platform-{r.Next(4, 6)}.png", new Point(2240, 808 + 80), 1, new Size(128, 128));
            CreateWorldBuildingElement(builder, $"yt_platform-{r.Next(4, 6)}.png", new Point(2368, 808 + 80), 1, new Size(128, 128));
            CreateWorldBuildingElement(builder, $"yt_platform-{r.Next(4, 6)}.png", new Point(2368, 680 + 80), 1, new Size(128, 128));
            CreateWorldBuildingElement(builder, $"yt_platform-{r.Next(4, 6)}.png", new Point(3584, 808 + 80), 1, new Size(128, 128));
            CreateWorldBuildingElement(builder, "yt_platform-6.png", new Point(2496, 552 + 80), 1, new Size(128, 384));
            
            XElement = 5376;
            for (int i = id; i < 75; i++)
            {
                CreateWorldBuildingElement(builder, "yt_platform-6.png", new Point(XElement, 552 + 80), 1, new Size(128, 384));
                XElement += 128;
            }

            CreateWorldBuildingElement(builder, $"yt_platform-{r.Next(4, 6)}.png", new Point(5120, 808 + 80), 1, new Size(128, 128));
            CreateWorldBuildingElement(builder, $"yt_platform-{r.Next(4, 6)}.png", new Point(5248, 808 + 80), 1, new Size(128, 128));
            CreateWorldBuildingElement(builder, $"yt_platform-{r.Next(4, 6)}.png", new Point(5248, 680 + 80), 1, new Size(128, 128));

            //Floating sprites
            XElement = 256;
            for (int i = id; i < 83; i++)
            {
                CreateWorldBuildingElement(builder, "yt_platform-3.png", new Point(XElement + 64, 760), 1, new Size(128, 32));
                XElement += 128;
            }

            XElement = 640;
            while (id < 89)
            {
                if (XElement < 1152)
                {
                    CreateWorldBuildingElement(builder, "yt_platform-3.png", new Point(XElement, 480), 1, new Size(128, 32));
                }
                else if (XElement > 1408)
                {
                    CreateWorldBuildingElement(builder, "yt_platform-3.png", new Point(XElement, 480), 1, new Size(128, 32));
                }

                XElement += 128;
            }

            XElement = 2624;
            for (int i = id; i < 91; i++)
            {
                CreateWorldBuildingElement(builder, "yt_platform-3.png", new Point(XElement, 552 + 80), 1, new Size(128, 32));
                XElement += 128;
            }

            XElement = 3840;
            for (int i = id; i < 94; i++)
            {
                CreateWorldBuildingElement(builder, "yt_platform-3.png", new Point(XElement, 680 + 80), 1, new Size(128, 32));
                XElement += 128;
            }

            XElement = 4096;
            for (int i = id; i < 102; i++)
            {
                if (i != 97)
                {
                    CreateWorldBuildingElement(builder, "yt_platform-3.png", new Point(XElement, 488 + 80), 1, new Size(128, 32));
                }
                XElement += 128;
            }

            //Adding wall sprites on the right
            YElement = 0;
            for (int i = id; i < 103; i++)
            {
                CreateWorldBuildingElement(builder, "yt_platform-6.png", new Point(7936, 552 - YElement + 80), 1, new Size(128, 384));
                YElement += 384;
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
