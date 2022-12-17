using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RestauranteService.Application.Services.ItemServiceHttpClient;
using RestauranteService.Application.Services.RabbitMqClient;
using RestauranteService.Core.Interfaces.Repository;
using RestauranteService.Core.Interfaces.Services;
using RestauranteService.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("RestauranteConnection");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IRestauranteRepository, RestauranteRepository>();

builder.Services.AddSingleton<IRabbitMqClient, RabbitMqClient>();

builder.Services.AddHttpClient<IItemServiceHttpClient, ItemServiceHttpClient>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestauranteService", Version = "v1" });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();
