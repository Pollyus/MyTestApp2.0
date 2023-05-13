using BLL.ViewModels;
using DBRepository.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repositories.AppRepositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory)
        { }

        public async Task<Project> GetProject(int ProjectId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                Project result = null;
                await foreach (Project project in context.Projects)
                {

                    if (project.Id == ProjectId) result = project;

                }
                return result;
                //return await context.Projects.Where(u => u.Id == ProjectId).Single();
            }
        }
        public List<ProjectViewModel> GetAllProjects()
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                List<ProjectViewModel> data = new List<ProjectViewModel>();
                foreach (Project project in context.Projects)
                {
                    ProjectViewModel viewModel = new ProjectViewModel();
                    viewModel.Id = project.Id;
                    viewModel.Name = project.Name;
                    viewModel.Path = project.Path;
                    data.Add(viewModel);
                }
                return data;
            }
        }

        public async Task AddProject(Project project)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.Projects.Add(project);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteProject(int projectId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var project = new Project() { Id = projectId };
                context.Projects.Remove(project);
                await context.SaveChangesAsync();
            }
        }
    }
}
