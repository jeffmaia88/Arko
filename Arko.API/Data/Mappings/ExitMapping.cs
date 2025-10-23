using Arko.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arko.API.Data.Mappings
{
    public class ExitMapping : IEntityTypeConfiguration<Exit>
    {
        public void Configure(EntityTypeBuilder<Exit> builder)
        {
            builder.ToTable("Saidas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Destination).HasColumnType("VARCHAR").HasMaxLength(255).IsRequired();
            builder.Property(x => x.ExitDate).IsRequired();

            

        }
    }
}
