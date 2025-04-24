using Microsoft.EntityFrameworkCore;
using SmartCity.API.Models;

namespace SmartCity.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Sensor> Sensores { get; set; }
}
