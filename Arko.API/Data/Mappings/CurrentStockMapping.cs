using Arko.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arko.API.Data.Mappings
{
    public class CurrentStockMapping : IEntityTypeConfiguration<CurrentStock>
    {
        public void Configure(EntityTypeBuilder<CurrentStock> builder)
        {
            builder.ToTable("Estoque Atual");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Status).HasConversion<int>().IsRequired();

            

        }
    }
}
