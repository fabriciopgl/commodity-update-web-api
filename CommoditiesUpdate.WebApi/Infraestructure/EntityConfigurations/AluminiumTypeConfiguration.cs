using CommoditiesUpdate.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommoditiesUpdate.WebApi.Infraestructure.EntityConfigurations
{
    public class AluminiumTypeConfiguration : IEntityTypeConfiguration<Aluminium>
    {
        public void Configure(EntityTypeBuilder<Aluminium> builder)
        {
            builder.ToTable("Commodities");
            builder.HasKey(c => new { c.Code, c.Date });
            builder.Property(c => c.Date)
                .HasConversion<DateOnlyConverter, DateOnlyComparer>();
            builder.Property(c => c.Price).HasPrecision(8,2);
        }
    }
}