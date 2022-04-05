using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.ModelTypeFluentAPIConfigurations
{
    class WeaponEntityTypeConfiguration : IEntityTypeConfiguration<Weapon>
    {
        public void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.HasBaseType<Item>();
            builder.Property(Weapon => Weapon.FireRate)
                   .HasConversion(FireRate => JsonSerializer.Serialize(FireRate, null),
                                  FireRate => JsonSerializer.Deserialize<TimeSpan>(FireRate, null));
        }
    }
}
