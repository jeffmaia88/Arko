using Arko.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arko.API.Data.Mappings
{
    public class AnalystMapping : IEntityTypeConfiguration<Analyst>
    {
        public void Configure(EntityTypeBuilder<Analyst> builder)
        {
            builder.ToTable("Analistas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(255).IsRequired();          


        }
    }
}
