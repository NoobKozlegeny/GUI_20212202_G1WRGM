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
    class CharacterEntityTypeConfiguration : IEntityTypeConfiguration<Character>
    {
        Random r = new Random();

        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.ToTable("Character");
            builder.HasKey(Pk => Pk.Id);
            builder.Property(Pk => Pk.Id)
                   .ValueGeneratedOnAdd();
            builder.Ignore(MapNavProp => MapNavProp.Map);
            builder.Ignore(Character => Character.IsTransform);
            builder.Property(CharacterFk => CharacterFk.MapLevel)
                   .IsRequired(false);

            builder.Property(Character => Character.Size)
                   .HasConversion(Size => JsonSerializer.Serialize(Size, null),
                                  Size => JsonSerializer.Deserialize<Size>(Size, null));
            builder.Property(Character => Character.Position)
                   .HasConversion(Position => JsonSerializer.Serialize(Position, null),
                                  Position => JsonSerializer.Deserialize<Point>(Position, null));

            builder.HasOne(CharacterNavProp => CharacterNavProp.Map)
                   .WithMany(MapNavProp => MapNavProp.Characters)
                   .HasForeignKey(CharacterFk => CharacterFk.MapLevel)
                   .OnDelete(DeleteBehavior.SetNull);

            //Youtube characters
            ConfigureYoutubeLevel(builder);
        }

        public void ConfigureYoutubeLevel(EntityTypeBuilder<Character> builder)
        {

        }
    }
}
