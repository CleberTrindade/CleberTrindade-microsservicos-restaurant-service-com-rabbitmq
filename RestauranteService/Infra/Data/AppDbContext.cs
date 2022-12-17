using Microsoft.EntityFrameworkCore;
using RestauranteService.Core.Models;

namespace RestauranteService.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {

    }

    public DbSet<Restaurante> Restaurantes { get; set; }
}
