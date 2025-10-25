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
            builder.HasIndex(x => x.EquipmentId).IsUnique();
            builder.HasOne(x => x.Equipment).WithMany().HasForeignKey(x => x.EquipmentId).OnDelete(DeleteBehavior.Restrict);



        }
    }
}
