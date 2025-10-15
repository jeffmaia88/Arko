using Arko.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arko.API.Data.Mappings
{
    public class EquipmentMapping : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipamentos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(x => x.Type).HasColumnType("VARCHAR").IsRequired();
            builder.Property(x => x.Brand).HasColumnType("VARCHAR").IsRequired();
            builder.Property(x => x.Model).HasColumnType("VARCHAR").IsRequired();
            builder.Property(x => x.Scrap).IsRequired();
        }
    }
}
