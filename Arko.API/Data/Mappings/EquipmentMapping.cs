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
            builder.Property(x => x.Patrimony).HasColumnType("VARCHAR").HasMaxLength(64).IsRequired();
            builder.Property(x => x.Type).HasColumnType("VARCHAR").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Brand).HasColumnType("VARCHAR").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Model).HasColumnType("VARCHAR").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Status).HasColumnType("INT").IsRequired();

            builder.HasIndex(x => x.Patrimony).IsUnique();

        }
    }
}
