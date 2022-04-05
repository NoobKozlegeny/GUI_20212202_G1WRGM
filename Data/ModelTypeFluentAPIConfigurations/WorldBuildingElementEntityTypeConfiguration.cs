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
    class WorldBuildingElementEntityTypeConfiguration : IEntityTypeConfiguration<WorldBuildingElement>
    {
        public void Configure(EntityTypeBuilder<WorldBuildingElement> builder)
        {
            builder.ToTable("WorldBuildingElement");
            builder.HasKey(pk => pk.Id);
            builder.Property(pk => pk.Id).ValueGeneratedOnAdd();
            builder.Ignore(WorldBuildingElementNavPop => WorldBuildingElementNavPop.Map);

            builder.HasOne(WorldBuildingElementNavPop => WorldBuildingElementNavPop.Map)
                   .WithMany(MapNavprop => MapNavprop.WorldElements)
                   .HasForeignKey(WorldBuildingElementNavPopFk => WorldBuildingElementNavPopFk.MapLevel)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
