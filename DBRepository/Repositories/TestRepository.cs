using Models;
using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
//using Options;

namespace DBRepository.Repositories
{
    public class TestRepository : BaseRepository, ITestRepository
    {
        public TestRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory) { }
        
        public async Task<Test> GetTest(int testId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Tests.Include(t => t.Name).Include(t => t.xmlReport).Include(t => t.UserId).FirstOrDefaultAsync(p => p.Id == testId);
            }
        }

        public async Task<List<string>> GetAllTests()
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Tests.Include(t => t.xmlReport).Select(t => t.Name).Distinct().ToListAsync();
            }
        }

        public async Task AddTest(Test test)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.Tests.Add(test);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteTest(int testId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var test = new Test() { Id = testId };
                context.Tests.Remove(test);
                await context.SaveChangesAsync();
            }
        }



    }
}
