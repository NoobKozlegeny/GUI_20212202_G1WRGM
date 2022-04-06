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
        public void Configure(EntityTypeBuilder<WorldBuildingElement> builder)
        {
            builder.ToTable("WorldBuildingElement");
            builder.HasKey(Pk => Pk.Id);
            builder.Property(Pk => Pk.Id)
                   .ValueGeneratedOnAdd();
            builder.Ignore(WorldBuildingElementNavProp => WorldBuildingElementNavProp.Map);
            builder.Ignore(WorldBuildingElementNavProp => WorldBuildingElementNavProp.PathToImg);
            builder.Property(WorldBuildingElementFk => WorldBuildingElementFk.MapLevel)
                   .IsRequired(false);

            builder.Property(WorldBuildingElement => WorldBuildingElement.Position)
                   .HasConversion(Position => JsonSerializer.Serialize(Position, null),
                                  Position => JsonSerializer.Deserialize<Point>(Position, null));

           
            builder.HasOne(WorldBuildingElementNavProp => WorldBuildingElementNavProp.Map)
                   .WithMany(MapNavprop => MapNavprop.WorldElements)
                   .HasForeignKey(WorldBuildingElementFk => WorldBuildingElementFk.MapLevel)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
