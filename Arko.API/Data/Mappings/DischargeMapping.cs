using Arko.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arko.API.Data.Mappings
{
    public class DischargeMapping : IEntityTypeConfiguration<Discharge>
    {
        public void Configure(EntityTypeBuilder<Discharge> builder)
        {
            builder.ToTable("Baixa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Reason).IsRequired();

            builder.HasOne(x => x.Equipament).WithOne(e => e.Discharge).HasForeignKey<Discharge>(x => x.EquipmentId).OnDelete(DeleteBehavior.Restrict);



        }
    }
}
