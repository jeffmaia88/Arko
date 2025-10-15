using Arko.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arko.API.Data.Mappings
{
    public class EntryMapping : IEntityTypeConfiguration<Entry>
    {
        public void Configure(EntityTypeBuilder<Entry> builder)
        {
            builder.ToTable("Entradas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Origin).HasColumnType("VARCHAR").HasMaxLength(255).IsRequired();
            builder.Property(x => x.EntryDate).IsRequired();

            builder.HasOne(x => x.Responsible).WithMany(e => e.Entries).HasForeignKey(x => x.IdAnalyst).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Equipment).WithMany(e => e.Entries).HasForeignKey(x => x.IdEquipment).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
