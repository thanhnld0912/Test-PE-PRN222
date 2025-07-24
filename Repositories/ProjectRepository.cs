using BusinessLogic.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public void SaveProject(Project project) => ProjectDAO.SaveProject(project);

        public void UpdateProject(Project project) => ProjectDAO.UpdateProject(project);

        public void DeleteProject(int id) => ProjectDAO.DeleteProject(id);

        public List<Project> GetAllProjects() => ProjectDAO.GetAllProjects();

        public Project? GetProjectById(int id) => ProjectDAO.GetProjectById(id);

        public List<Project> GetProjectsByTeamId(int teamId) => ProjectDAO.GetProjectsByTeamId(teamId);
    }
}
