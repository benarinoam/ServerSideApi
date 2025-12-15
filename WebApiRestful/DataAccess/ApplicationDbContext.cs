using Microsoft.EntityFrameworkCore;
using WebApirestful.Models;
namespace WebApirestful.DataAccess 
{
    public class ApplicationDbContext : DbContext
    {
        // This constructor is required for ASP.NET Core Dependency Injection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSet properties for your database tables here. 
        // For example, if you have a 'Product' model:
         public DbSet<WeatherCast> WeatherCasts { get; set; }
    }
    
}