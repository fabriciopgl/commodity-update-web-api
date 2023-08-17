using CommoditiesUpdate.WebApi.Domain;

namespace CommoditiesUpdate.WebApi.Infraestructure.Repositories
{
    public interface IAluminiumRepository
    {
        Task Add(Aluminium aluminium);
        Task CommitAsync();
        Task<IEnumerable<Aluminium>> GetAllAsync();
    }
}
