using Commodities.WebApi.Domain.Models;
using CommoditiesUpdate.WebApi.Domain;

namespace CommoditiesUpdate.WebApi.Infraestructure.Repositories
{
    public interface ICommodityRepository
    {
        Task Add(Commodity commodity);
        Task CommitAsync();
        Task<IEnumerable<Commodity>> GetAllAsync();
        Task <Commodity> GetByCodeAndDateAsync(int code, DateOnly date);
        void Remove(Commodity commodity);
    }
}
