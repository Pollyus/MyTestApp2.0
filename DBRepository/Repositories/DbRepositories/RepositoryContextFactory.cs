using DBRepository.Interfaces;
using DBRepository.Repositories.DbRepositories;
using Microsoft.EntityFrameworkCore;

public class RepositoryContextFactory : IRepositoryContextFactory
{
    public RepositoryDbContext CreateDbContext(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RepositoryDbContext>();
        optionsBuilder.UseNpgsql(connectionString);
        //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        return new RepositoryDbContext(optionsBuilder.Options);
    }
}