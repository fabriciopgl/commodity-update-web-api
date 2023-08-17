using CommoditiesUpdate.WebApi.Infraestructure;
using CommoditiesUpdate.WebApi.Infraestructure.EntityConfigurations;
using CommoditiesUpdate.WebApi.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<IAluminiumRepository, AluminiumRepository>();

// DbContext de todos os commodities
builder.Services.AddDbContext<CommoditiesDbContext>(
o =>
{
    o.UseSqlServer("name=ConnectionStrings:Commodities");
});

// Conversor de DateTime para DateOnly (quando busca do banco e serializa para Json)
builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
