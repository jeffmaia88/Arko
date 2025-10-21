using Arko.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arko.API.Data.Mappings
{
    public class CurrentStockMapping : IEntityTypeConfiguration<CurrentStock>
    {
        public void Configure(EntityTypeBuilder<CurrentStock> builder)
        {
            builder.ToTable("EstoqueAtual");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Status).HasConversion<int>().IsRequired();

            builder.HasOne(x => x.Equipment).WithOne(e => e.CurrentStock).HasForeignKey<CurrentStock>(x => x.EquipmentId).OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.EquipmentId).IsUnique();

            

        }
    }
}
