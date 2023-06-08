using DynemicSun.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DynemicSun;

public class ApplicationContext : DbContext
{
    public DbSet<Year> Years { get; set; } = null!;
    public DbSet<Month> Months { get; set; } = null!;
    public DbSet<WeatherMeasurement> Measurements { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
}