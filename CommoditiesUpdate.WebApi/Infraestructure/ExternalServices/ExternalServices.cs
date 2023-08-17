using Newtonsoft.Json;
using CSharpFunctionalExtensions;
using CommoditiesUpdate.WebApi.Domain;

namespace Commodities.WebApi.Infraestructure.ExternalServices
{
    public class ExternalServices : IExternalServices
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public ExternalServices(HttpClient httpClient, IConfiguration configuration) 
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<Result<CommoditiesDTO>> GetCommoditiesDataAsync()
        {
            var request = await _httpClient.GetAsync(_configuration.GetSection("Commodity")["URL"]);
            if (!request.IsSuccessStatusCode)
                return Result.Failure<CommoditiesDTO>("Status " + request.StatusCode + " fetching data from external API");

            var requestContent = await request.Content.ReadAsStringAsync();
            if (requestContent == null)
                return Result.Failure<CommoditiesDTO>("No commodity data fetched from external API");

            var responseBody = JsonConvert.DeserializeObject<CommoditiesDTO>(requestContent);
            if(responseBody == null)
                return Result.Failure<CommoditiesDTO>("Fail converting data between types");

            return Result.Success(responseBody);
        }
    }
}