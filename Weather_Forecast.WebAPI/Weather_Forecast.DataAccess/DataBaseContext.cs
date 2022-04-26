using Microsoft.EntityFrameworkCore;
using Weather_Forecast.DataAccess.Models;

namespace Weather_Forecast.DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Weather> Weathers { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
