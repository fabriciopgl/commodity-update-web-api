using Microsoft.AspNetCore.Mvc;
using Commodities.WebApi.Helpers;
using Commodities.WebApi.Domain.Factories;
using CommoditiesUpdate.WebApi.Infraestructure.Repositories;
using Commodities.WebApi.Infraestructure.ExternalServices;

namespace CommoditiesUpdate.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommoditiesController : ControllerBase
    {
        private readonly ICommodityRepository _commodityRepository;
        private readonly IExternalServices _externalService;

        public CommoditiesController(ICommodityRepository commodityRepository, IExternalServices externalService)
        {
            _commodityRepository = commodityRepository;
            _externalService = externalService;
        }

        [HttpPost("update/{code:int}")]
        public async Task<IActionResult> UpdateAsync(int code)
        {
            var responseBody = await _externalService.GetCommoditiesDataAsync();
            if (responseBody.IsFailure)
                return BadRequest(new AppError(Request.Path, "Error fetching external data", responseBody.Error));

            var commodity = CommodityFactory.Create(responseBody.Value, code);
            if(commodity.IsFailure)
                return BadRequest(new AppError(Request.Path, "Error creating commodity", commodity.Error));

            var oldCommodity = await _commodityRepository.GetByCodeAndDateAsync(code, commodity.Value.Date);
            if (oldCommodity != null)
            {
                _commodityRepository.Remove(oldCommodity);
                await _commodityRepository.CommitAsync();
            }

            await _commodityRepository.Add(commodity.Value);
            await _commodityRepository.CommitAsync();

            return Ok(commodity.Value);
        }

        [HttpGet]
        public async Task <IActionResult> GetAllCommodities()
        {
            var aluminium = await _commodityRepository.GetAllAsync();
            if (!aluminium.Any())
                return NotFound(new AppError(Request.Path, "No commodity data", "There is no data recorded in your database"));

            return Ok(aluminium);
        }

        [HttpGet("{code:int}/{date}")]
        public async Task<IActionResult> GetByCodeAndDateAsync(int code, string date)
        {
            if(!DateOnly.TryParse(date, out var parsedData))
                return BadRequest(new AppError(Request.Path, "Invalid parameter", "The date parameter isn't valid"));

            var aluminium = await _commodityRepository.GetByCodeAndDateAsync(code, parsedData);
            if (aluminium == null)
                return NotFound(new AppError(Request.Path, "No commodity data", "There is no data recorded in your database for date you've searched"));

            return Ok(aluminium);
        }
    }
}