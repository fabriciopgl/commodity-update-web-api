using CSharpFunctionalExtensions;
using CommoditiesUpdate.WebApi.Domain;
using Commodities.WebApi.Domain.Models;

namespace Commodities.WebApi.Domain.Factories
{
    public static class CommodityFactory
    {
        private static DateTime SearchDataRange => DateTime.Today.AddDays(-1);

        private static readonly Dictionary<int, Func<CommoditiesDTO, (decimal currency, string name)>> CommodityMappings = new()
        {
            { 1, commodities => (commodities.Results.Find(f => f.Data == SearchDataRange)?.Aluminio ?? 0, "Aluminum" )},
            { 2, commodities => (commodities.Results.Find(f => f.Data == SearchDataRange)?.Cobre ?? 0, "Copper" )},
            { 3, commodities => (commodities.Results.Find(f => f.Data == SearchDataRange)?.Zinco ?? 0, "Zinc" )},
            { 4, commodities => (commodities.Results.Find(f => f.Data == SearchDataRange)?.Niquel ?? 0, "Nickel" )},
            { 5, commodities => (commodities.Results.Find(f => f.Data == SearchDataRange)?.Chumbo ?? 0, "Lead" )},
            { 6, commodities => (commodities.Results.Find(f => f.Data == SearchDataRange)?.Dolar ?? 0, "Dollar" )},
            { 7, commodities => (commodities.Results.Find(f => f.Data == SearchDataRange)?.Estanho ?? 0, "Tin")},
        };

        public static Result<Commodity> Create(CommoditiesDTO commodities, int code)
        {
            if (CommodityMappings.TryGetValue(code, out var getValueFunc))
            {
                var (currency, name) = getValueFunc(commodities);
                var commodityData = SearchDataRange;

                var commodity = Commodity.Create(code, DateOnly.FromDateTime(commodityData), currency, name);
                if (commodity.IsFailure)
                    return Result.Failure<Commodity>(commodity.Error);

                return Result.Success<Commodity>(commodity.Value);
            }

            return Result.Failure<Commodity>("Invalid commodity code.");
        }
    }
}