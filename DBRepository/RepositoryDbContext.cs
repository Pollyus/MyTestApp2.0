using Microsoft.EntityFrameworkCore;
using Models;


namespace DBRepository
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
        { }

        public DbSet<TeamLeader> TeamLeaders { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestsGroup> TestsGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Project> Projects { get; set; }
        
    }
}
