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
        public void Configure(EntityTypeBuilder<Collectible> builder)
        {
            builder.HasBaseType<Item>();
            builder.Property(Collectible => Collectible.Position)
                   .HasConversion(Position => JsonSerializer.Serialize(Position, null),
                                  Position => JsonSerializer.Deserialize<Point>(Position, null));
        }
    }
}
