using Commodities.WebApi.Domain.Models;
using CommoditiesUpdate.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace CommoditiesUpdate.WebApi.Infraestructure.Repositories
{
    public class CommodityRepository : ICommodityRepository
    {
        private readonly CommoditiesDbContext _commoditiesDbContext;

        public CommodityRepository(CommoditiesDbContext commoditiesDbContext)
        {
            _commoditiesDbContext = commoditiesDbContext;
        }

        public async Task Add(Commodity commodity)
        {
            await _commoditiesDbContext.AddRangeAsync(commodity);
        }

        public async Task CommitAsync()
        {
            await _commoditiesDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Commodity>> GetAllAsync()
        {
            return await _commoditiesDbContext.
                Commodities
                .ToListAsync();
        }

        public async Task<Commodity> GetByCodeAndDateAsync(int code, DateOnly date)
        {
            return await _commoditiesDbContext.
                Commodities
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Code == code && d.Date == date);
        }

        public void Remove(Commodity commodity)
        {
            _commoditiesDbContext.Remove(commodity);
        }
    }
}
