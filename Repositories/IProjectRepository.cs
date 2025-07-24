using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProjectRepository
    {
        void SaveProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int id);
        List<Project> GetAllProjects();
        Project? GetProjectById(int id);
        List<Project> GetProjectsByTeamId(int teamId);
    }
}
