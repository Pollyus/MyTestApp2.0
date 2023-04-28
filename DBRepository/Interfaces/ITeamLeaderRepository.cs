using DBRepository.ViewModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
