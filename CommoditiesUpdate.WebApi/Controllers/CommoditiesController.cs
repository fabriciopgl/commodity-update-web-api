using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using CommoditiesUpdate.WebApi.Domain;
using CommoditiesUpdate.WebApi.Infraestructure.Repositories;

namespace CommoditiesUpdate.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommoditiesController : ControllerBase
    {
        private readonly IAluminiumRepository _aluminiumRepository;
        private readonly HttpClient _httpClient;

        public CommoditiesController(IAluminiumRepository aluminiumRepository, HttpClient httpClient)
        {
            _aluminiumRepository = aluminiumRepository;
            _httpClient = httpClient;
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync()
        {
            var response = await _httpClient.GetAsync("https://lme.gorilaxpress.com/cotacao/2cf4ff0e-8a30-48a5-8add-f4a1a63fee10/json/").Result.Content.ReadAsStringAsync();
            if (response == null)
                return BadRequest();

            var responseBody = JsonConvert.DeserializeObject<CommoditiesDTO>(response);
            var commoditieDataToday = responseBody.Results.Find(f => f.Data == DateTime.Today.AddDays(-1));
            if (commoditieDataToday == null)
                return BadRequest();

            var aluminium = Aluminium.Create(1, DateOnly.FromDateTime(commoditieDataToday.Data), commoditieDataToday.Aluminio);
            if (aluminium.IsFailure)
                return BadRequest();

            await _aluminiumRepository.Add(aluminium.Value);
            await _aluminiumRepository.CommitAsync();

            return Ok(aluminium.Value);
        }

        [HttpGet]
        public async Task <IActionResult> GetAllCommodities()
        {
            var aluminium = await _aluminiumRepository.GetAllAsync();
            if (!aluminium.Any())
                return BadRequest();

            return Ok(aluminium);
        }
    }
}