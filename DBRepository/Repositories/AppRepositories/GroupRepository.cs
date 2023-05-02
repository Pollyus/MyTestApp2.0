

using BLL.ViewModels;
using DBRepository.Interfaces;
using Models;

namespace DBRepository.Repositories.AppRepositories
{

    public class GroupRepository : BaseRepository, ITestGroupRepository
    {
        public GroupRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory)
        { }

        public async Task<TestsGroup> GetGroup(int GroupId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                TestsGroup result = null;
                await foreach (TestsGroup group in context.TestsGroups)
                {

                    if (group.Id == GroupId) result = group;

                }
                return result;
                //return await context.Groups.Where(u => u.Id == GroupId).Single();
            }
        }
        public List<GroupViewModel> GetAllGroups()
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                List<GroupViewModel> data = new List<GroupViewModel>();
                foreach (TestsGroup group in context.TestsGroups)
                {
                    GroupViewModel viewModel = new GroupViewModel();
                    viewModel.Id = group.Id;
                    viewModel.xmlReport = group.xmlReport;

                    data.Add(viewModel);
                }
                return data;
            }
        }

        public async Task AddGroup(TestsGroup group)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.TestsGroups.Add(group);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteGroup(int groupId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var group = new TestsGroup() { Id = groupId };
                context.TestsGroups.Remove(group);
                await context.SaveChangesAsync();
            }
        }

    }
}


