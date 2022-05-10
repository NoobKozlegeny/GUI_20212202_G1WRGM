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
            CreateNPC(builder, "TwistBrainlet.png", "Watergun.png", new Point(768, 888), 1, 2, 1, 1, new Size(128, 128));
            CreateNPC(builder, "DreamStan.png", "Watergun.png", new Point(1536, 888), 1, 2, 1, 1, new Size(128, 128));
            CreateNPC(builder, "TwistBrainlet.png", "Watergun.png", new Point(2688, 888), 1, 2, 1, 1, new Size(128, 128));
            CreateNPC(builder, "AngryDoge.png", "Watergun.png", new Point(3360, 888), 1, 2, 1, 1, new Size(128, 128));
            CreateNPC(builder, "NikoAvocado.png", "Watergun.png", new Point(4096, 888), 1, 2, 1, 1, new Size(128, 128));
            CreateNPC(builder, "DreamStan.png", "Watergun.png", new Point(4352, 888), 1, 2, 1, 1, new Size(128, 128));
            CreateNPC(builder, "TwistBrainlet.png", "Watergun.png", new Point(4608, 888), 1, 2, 1, 1, new Size(128, 128));



            CreateNPC(builder, "KoviBossFinal2.png", "Empty.png", new Point(7520, 386), 10, 69, 1, 1, new Size(384, 576));
        }

        public void CreateNPC(EntityTypeBuilder<NPC> builder, string NPCImg, string WeaponImg, Point position, int armour, int health, int speed, int mapLevel, Size size)
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
                Size = size,
                Id = id
            });
            
            id++;
        }
    }
}
