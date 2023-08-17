using Commodities.WebApi.Domain.Models;
using CommoditiesUpdate.WebApi.Domain;
using CommoditiesUpdate.WebApi.Infraestructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CommoditiesUpdate.WebApi.Infraestructure
{
    public class CommoditiesDbContext : DbContext
    {
        public CommoditiesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Commodity> Commodities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommodityTypeConfiguration());
        }
    }
}
