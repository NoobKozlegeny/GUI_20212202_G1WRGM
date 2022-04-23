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
            //builder.Ignore(MapNavProp => MapNavProp.PathToImg);
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
            ////Player
            //builder.HasData(new Player()
            //{
            //    Name = "Player",
            //    PathToImg = new Uri(System.IO.Path.Combine("Assets", "Characters", "Players", "Chad.png"), UriKind.RelativeOrAbsolute),
            //    Inventory = new Inventory() { PathToSelectedItemImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "SuperShotgun.png"), UriKind.RelativeOrAbsolute) },
            //    Armour = 0,
            //    HealthPoints = 5,
            //    Speed = 1,
            //    MapLevel = 1,
            //    Position = new Point(0, 952),
            //    Size = new Size(128, 128),
            //    Id = 1
            //});

            //int XElement = 256;
            //int randomResult;
            //int id = 2;

            //for (int i = id; i < 32; i++)
            //{
            //    randomResult = r.Next(1, 3);
            //    builder.HasData(new NPC()
            //    {
            //        Name = $"NPC{i - 1}",
            //        PathToImg = new Uri(System.IO.Path.Combine("Assets", "Characters", "NPCS", "TwistBrainlet.png"), UriKind.RelativeOrAbsolute),
            //        PathToWeaponImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "Watergun.png"), UriKind.RelativeOrAbsolute),
            //        Armour = 0,
            //        HealthPoints = 2,
            //        Speed = 1,
            //        MapLevel = 1,
            //        Position = new Point(XElement, 952),
            //        Size = new Size(128, 128),
            //        Id = i
            //    });

            //    XElement += 128;
            //    id = i;
            //}
        }
    }
}
