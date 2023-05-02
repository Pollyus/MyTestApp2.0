using Models;
using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using BLL.ViewModels;

namespace DBRepository.Repositories.AppRepositories
{
    public class TestRepository : BaseRepository, ITestRepository
    {
        public TestRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory)
        { }

        public async Task<Test> GetTest(int TestId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                Test result = null;
                await foreach (Test test in context.Tests)
                {

                    if (test.Id == TestId) result = test;

                }
                return result;
                //return await context.Tests.Where(u => u.Id == TestId).Single();
            }
        }
        public List<TestViewModel> GetAllTests()
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                List<TestViewModel> data = new List<TestViewModel>();
                foreach (Test test in context.Tests)
                {
                    TestViewModel viewModel = new TestViewModel();
                    viewModel.Id = test.Id;
                    data.Add(viewModel);
                }
                return data;
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
