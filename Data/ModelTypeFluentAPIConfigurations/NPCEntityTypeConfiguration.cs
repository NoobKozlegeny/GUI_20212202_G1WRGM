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

        public void Configure(EntityTypeBuilder<NPC> builder)
        {
            builder.HasBaseType<Character>();
            //builder.Ignore(NPCNavProp => NPCNavProp.PathToWeaponImg);

            //Youtube characters
            ConfigureYoutubeLevel(builder);
        }

        public void ConfigureYoutubeLevel(EntityTypeBuilder<NPC> builder)
        {
            int XElement = 256;
            int randomResult;
            int id = 2;

            for (int i = id; i < 32; i++)
            {
                randomResult = r.Next(1, 3);
                builder.HasData(new NPC()
                {
                    Name = $"NPC{i - 1}",
                    PathToImg = new Uri(System.IO.Path.Combine("Assets", "Characters", "NPCS", "TwistBrainlet.png"), UriKind.RelativeOrAbsolute),
                    PathToWeaponImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "Watergun.png"), UriKind.RelativeOrAbsolute),
                    Armour = 0,
                    HealthPoints = 2,
                    Speed = 1,
                    MapLevel = 1,
                    Position = new Point(XElement, 952),
                    Size = new Size(128, 128),
                    Id = i
                });

                XElement += 128;
                id = i;
            }
        }
    }
}
