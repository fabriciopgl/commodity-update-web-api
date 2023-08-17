using Commodities.WebApi.Domain.Models;
using CommoditiesUpdate.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommoditiesUpdate.WebApi.Infraestructure.EntityConfigurations
{
    public class CommodityTypeConfiguration : IEntityTypeConfiguration<Commodity>
    {
        public void Configure(EntityTypeBuilder<Commodity> builder)
        {
            builder.ToTable("Commodities");
            builder.HasKey(c => new { c.Code, c.Date });
            builder.Property(c => c.Date)
                .HasConversion<DateOnlyConverter, DateOnlyComparer>();
            builder.Property(c => c.Currency).HasPrecision(8,2);
            builder.Property(n => n.Name).HasMaxLength(15);
        }
    }
}