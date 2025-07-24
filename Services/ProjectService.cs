using BusinessLogic.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;

        public ProjectService()
        {
            projectRepository = new ProjectRepository();
        }

        public void SaveProject(Project project) => projectRepository.SaveProject(project);

        public void UpdateProject(Project project) => projectRepository.UpdateProject(project);

        public void DeleteProject(int id) => projectRepository.DeleteProject(id);

        public List<Project> GetAllProjects() => projectRepository.GetAllProjects();

        public Project? GetProjectById(int id) => projectRepository.GetProjectById(id);

        public List<Project> GetProjectsByTeamId(int teamId) => projectRepository.GetProjectsByTeamId(teamId);
    }
}
