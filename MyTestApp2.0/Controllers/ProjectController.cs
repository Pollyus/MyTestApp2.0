using BLL.ViewModels;
using DBRepository.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Models;

namespace MyTestApp2.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    public class ProjectController : Controller
    {
        IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [Route("project")]
        [HttpGet("get")]
        public async Task<Project> GetProject(int projectId)
        {
            return await _projectRepository.GetProject(projectId);
        }


        [Route("project")]
        [HttpGet("get/all")]
        public List<ProjectViewModel> GetAllProjects()
        {
            return _projectRepository.GetAllProjects();
        }


        [Route("project")]
        [HttpPost("add")]
        public async Task AddProject(Project project)
        {
            await _projectRepository.AddProject(project);
        }


        [Route("project")]
        [HttpDelete("delete")]
        public async Task DeletePost(int projectId)
        {
            await _projectRepository.DeleteProject(projectId);
        }

    }
}
