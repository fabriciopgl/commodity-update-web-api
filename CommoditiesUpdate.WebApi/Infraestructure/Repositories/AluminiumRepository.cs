using CommoditiesUpdate.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace CommoditiesUpdate.WebApi.Infraestructure.Repositories
{
    public class AluminiumRepository : IAluminiumRepository
    {
        private readonly CommoditiesDbContext _commoditiesDbContext;

        public AluminiumRepository(CommoditiesDbContext commoditiesDbContext)
        {
            _commoditiesDbContext = commoditiesDbContext;
        }

        public async Task Add(Aluminium aluminium)
        {
            await _commoditiesDbContext.AddRangeAsync(aluminium);
        }

        public async Task CommitAsync()
        {
            await _commoditiesDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Aluminium>> GetAllAsync()
        {
            return await _commoditiesDbContext.
                Aluminium
                .ToListAsync();
        }
    }
}
