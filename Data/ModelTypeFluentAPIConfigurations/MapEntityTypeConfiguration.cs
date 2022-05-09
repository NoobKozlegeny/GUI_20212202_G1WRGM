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
    class MapEntityTypeConfiguration : IEntityTypeConfiguration<Map>
    {
        public void Configure(EntityTypeBuilder<Map> builder)
        {
            builder.ToTable("Map");
            builder.HasKey(Pk => Pk.Level);
            builder.Property(Pk => Pk.Level).ValueGeneratedOnAdd();
            //builder.Ignore(MapNavProp => MapNavProp.PathToImg);
            builder.Ignore(MapNavProp => MapNavProp.Characters);
            builder.Ignore(MapNavProp => MapNavProp.Items);
            builder.Ignore(MapNavProp => MapNavProp.WorldElements);

            builder.Property(Map => Map.Size)
                   .HasConversion(Size => JsonSerializer.Serialize(Size, null),
                                  Size => JsonSerializer.Deserialize<Size>(Size, null));
            builder.Property(Map => Map.PathToImg)
                   .HasConversion(Image => JsonSerializer.Serialize(Image, null),
                                  Image => JsonSerializer.Deserialize<Uri>(Image, null));

            builder.HasMany(CharacterNavProp => CharacterNavProp.Characters)
                   .WithOne(MapNavProp => MapNavProp.Map)
                   .HasForeignKey(CharacterFk => CharacterFk.MapLevel)
                   .OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(ItemNavProp => ItemNavProp.Items)
                   .WithOne(MapNavProp => MapNavProp.Map)
                   .HasForeignKey(ItemFk => ItemFk.MapLevel)
                   .OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(WorldBuildingElementNavProp => WorldBuildingElementNavProp.WorldElements)
                   .WithOne(MapNavProp => MapNavProp.Map)
                   .HasForeignKey(WorldBuildingElementFk => WorldBuildingElementFk.MapLevel)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(new Map()
            {
                PathToImg = new Uri(System.IO.Path.Combine("Assets", "Background", "GameLevelBackground.png"), UriKind.RelativeOrAbsolute),
                Level = 1,
                Size = new System.Drawing.Size(8000, 1080),
                Characters = new List<Character>(),
                Items = new List<Item>(),
                WorldElements = new List<WorldBuildingElement>()
            },
            new Map()
            {
                PathToImg = new Uri(System.IO.Path.Combine("Assets", "Background", "GameLevelBackground.png"), UriKind.RelativeOrAbsolute),
                Level = 2,
                Size = new System.Drawing.Size(8000, 1080),
                Characters = new List<Character>(),
                Items = new List<Item>(),
                WorldElements = new List<WorldBuildingElement>()
            });
        }
    }
}
