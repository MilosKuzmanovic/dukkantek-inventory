using Dukkantek.Inventory.API.Middleware;
using Dukkantek.Inventory.Application.Services.Implementation;
using Dukkantek.Inventory.Application.Services.Interface;
using Dukkantek.Inventory.Infrastructure.Context;
using Dukkantek.Inventory.Infrastructure.Repositories.Implementation;
using Dukkantek.Inventory.Infrastructure.Repositories.Interface;
using Dukkantek.Inventory.Model.Entities;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddDbContext<InventoryDbContext>();

services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAutoMapper(Assembly.Load("Dukkantek.Inventory.Shared"));

services.AddScoped<IProductService, ProductService>();

services.AddScoped<IProductRepository, ProductRepository>();
services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run("http://localhost:4000");
