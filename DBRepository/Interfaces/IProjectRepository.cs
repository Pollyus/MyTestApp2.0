using BLL.ViewModels;
using Models;

namespace DBRepository.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> GetProject(int id);
        List<ProjectViewModel> GetAllProjects();
        Task AddProject(Project project);
        Task DeleteProject(int projectId);
    }
}
