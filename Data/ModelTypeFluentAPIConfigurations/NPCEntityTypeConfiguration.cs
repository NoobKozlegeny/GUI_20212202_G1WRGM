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
    class NPCEntityTypeConfiguration : IEntityTypeConfiguration<NPC>
    {
        public void Configure(EntityTypeBuilder<NPC> builder)
        {
            builder.HasBaseType<Character>();
        }
    }
}
