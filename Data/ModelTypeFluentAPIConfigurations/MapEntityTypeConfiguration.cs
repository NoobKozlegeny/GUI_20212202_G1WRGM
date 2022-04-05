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
    class MapEntityTypeConfiguration : IEntityTypeConfiguration<Map>
    {
        public void Configure(EntityTypeBuilder<Map> builder)
        {
            builder.ToTable("Map");
            builder.HasKey(pk => pk.Level);
            builder.Property(pk => pk.Level).ValueGeneratedOnAdd();
            builder.Ignore(MapNavProp => MapNavProp.Characters);
            builder.Ignore(MapNavProp => MapNavProp.Items);
            builder.Ignore(MapNavProp => MapNavProp.WorldElements);

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
        }
    }
}
