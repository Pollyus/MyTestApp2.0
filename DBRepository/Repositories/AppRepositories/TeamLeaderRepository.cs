using BLL.ViewModels;
using DBRepository.Interfaces;
using Models;

namespace DBRepository.Repositories.AppRepositories
{
    public class TeamLeaderRepository : BaseRepository, ITeamLeaderRepository
    {
        public TeamLeaderRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory)
        { }

        public async Task<TeamLeader> GetTeamLeader(int TeamLeaderId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                TeamLeader result = null;
                await foreach (TeamLeader teamLeader in context.TeamLeaders)
                {

                    if (teamLeader.Id == TeamLeaderId) result = teamLeader;

                }
                return result;

            }
        }
        public List<TeamLeaderViewModel> GetAllTeamLeaders()
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                List<TeamLeaderViewModel> data = new List<TeamLeaderViewModel>();
                foreach (TeamLeader teamLeader in context.TeamLeaders)
                {
                    TeamLeaderViewModel viewModel = new TeamLeaderViewModel();
                    viewModel.Id = teamLeader.Id;
                    data.Add(viewModel);
                }
                return data;
            }
        }

        public async Task AddTeamLeader(TeamLeader teamLeader)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {

                context.TeamLeaders.Add(teamLeader);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteTeamLeader(int teamLeaderId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var teamLeader = new TeamLeader() { Id = teamLeaderId };
                context.TeamLeaders.Remove(teamLeader);
                await context.SaveChangesAsync();
            }
        }
    }
}
