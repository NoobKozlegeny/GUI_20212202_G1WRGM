using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ModelTypeFluentAPIConfigurations
{
    class NPCEntityTypeConfiguration : IEntityTypeConfiguration<NPC>
    {
        Random r = new Random();
        int id = 2; //Because the id with 1 one is the player

        public void Configure(EntityTypeBuilder<NPC> builder)
        {
            builder.HasBaseType<Character>();
            //builder.Ignore(NPCNavProp => NPCNavProp.PathToWeaponImg);

            //Youtube characters
            ConfigureYoutubeLevel(builder);
        }

        public void ConfigureYoutubeLevel(EntityTypeBuilder<NPC> builder)
        {
            CreateNPC(builder, "TwistBrainlet.png", "Watergun.png", new Point(768, 888 - 80), 1, 2, 1, 1);
            CreateNPC(builder, "TwistBrainlet.png", "Watergun.png", new Point(1536, 888 - 80), 1, 2, 1, 1);
        }

        public void CreateNPC(EntityTypeBuilder<NPC> builder, string NPCImg, string WeaponImg, Point position, int armour, int health, int speed, int mapLevel)
        {
            builder.HasData(new NPC()
            {
                Name = $"NPC{id - 1}",
                PathToImg = new Uri(System.IO.Path.Combine("Assets", "Characters", "NPCS", NPCImg), UriKind.RelativeOrAbsolute),
                PathToWeaponImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", WeaponImg), UriKind.RelativeOrAbsolute),
                Armour = armour,
                HealthPoints = health,
                Speed = speed,
                MapLevel = mapLevel,
                Position = position,
                Size = new Size(128, 128),
                Id = id
            });
            
            id++;
        }
    }
}
