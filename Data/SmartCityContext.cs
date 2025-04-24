using Microsoft.EntityFrameworkCore;
using SmartCity.API.Models;

public class SmartCityContext : DbContext
{
    public SmartCityContext(DbContextOptions<SmartCityContext> options) : base(options) { }

    public DbSet<Sensor> Sensores { get; set; }
}
