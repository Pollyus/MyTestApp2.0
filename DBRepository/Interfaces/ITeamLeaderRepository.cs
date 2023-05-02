using BLL.ViewModels;
using Models;


namespace DBRepository.Interfaces
{
    public interface ITeamLeaderRepository
    {
        Task<TeamLeader> GetTeamLeader(int id);
        List<TeamLeaderViewModel> GetAllTeamLeaders();
        Task AddTeamLeader(TeamLeader teamLeader);
        Task DeleteTeamLeader(int teamLeaderId);
    }
}
