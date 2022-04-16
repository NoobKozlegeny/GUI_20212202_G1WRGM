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
    class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasBaseType<Character>();

            builder.HasOne(PlayerNavProp => PlayerNavProp.Inventory)
                   .WithOne(InventoryNavProp => InventoryNavProp.Player)
                   .HasForeignKey<Inventory>(PlayerFk => PlayerFk.PlayerId)
                   .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
