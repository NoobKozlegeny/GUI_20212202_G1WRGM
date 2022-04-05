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
    class CharacterEntityTypeConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.ToTable("Character");
            builder.HasKey(pk => pk.Id);
            builder.Ignore(MapNavProp => MapNavProp.Map);

            builder.HasOne(CharacterNavProp => CharacterNavProp.Map)
                   .WithMany(MapNavProp => MapNavProp.Characters)
                   .HasForeignKey(CharacterFk => CharacterFk.MapLevel);
        }
    }
}
