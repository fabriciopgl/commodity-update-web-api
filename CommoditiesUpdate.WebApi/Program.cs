using Microsoft.EntityFrameworkCore;
using CommoditiesUpdate.WebApi.Infraestructure;
using Commodities.WebApi.Infraestructure.ExternalServices;
using CommoditiesUpdate.WebApi.Infraestructure.Repositories;
using CommoditiesUpdate.WebApi.Infraestructure.EntityConfigurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<IExternalServices, ExternalServices>();
builder.Services.AddScoped<ICommodityRepository, CommodityRepository>();

// DbContext from all commodities
builder.Services.AddDbContext<CommoditiesDbContext>(
o =>
{
    o.UseSqlServer("name=ConnectionStrings:Commodities");

});

// DateTime to DateOnly  converter (when fetch data from database and serialize as Json)
builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health");
});

app.Run();