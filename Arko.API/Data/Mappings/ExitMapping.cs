using Arko.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arko.API.Data.Mappings
{
    public class ExitMapping : IEntityTypeConfiguration<Exit>
    {
        public void Configure(EntityTypeBuilder<Exit> builder)
        {
            builder.ToTable("Saídas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Destination).HasColumnType("VARCHAR").HasMaxLength(255).IsRequired();
            builder.Property(x => x.ExitDate).IsRequired();

            builder.HasOne(x => x.Responsible).WithMany(e => e.Exits).HasForeignKey(x => x.IdAnalyst);
            builder.HasOne(x => x.Equipment).WithMany(e => e.Exits).HasForeignKey(e => e.IdEquipment);

        }
    }
}
