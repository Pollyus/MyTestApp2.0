using DBRepository;
using Microsoft.EntityFrameworkCore;

namespace MyTestApp2._0.Extentions
{
    public static class ServiceExtensions
    {
        public static void ConfigureMyPostgreSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryDbContext>();
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
