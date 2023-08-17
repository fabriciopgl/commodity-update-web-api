using CSharpFunctionalExtensions;
using CommoditiesUpdate.WebApi.Domain;

namespace Commodities.WebApi.Infraestructure.ExternalServices
{
    public interface IExternalServices
    {
        Task<Result<CommoditiesDTO>> GetCommoditiesDataAsync();
    }
}