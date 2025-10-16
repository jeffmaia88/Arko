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
            builder.Property(x => x.Name).HasColumnType("VARCHAR").IsRequired();

            builder.HasMany(x => x.Entries).WithOne(e => e.Responsible).HasForeignKey(e => e.IdAnalyst).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Exits).WithOne(e => e.Responsible).HasForeignKey(e => e.IdAnalyst).OnDelete(DeleteBehavior.Restrict);




        }
    }
}
