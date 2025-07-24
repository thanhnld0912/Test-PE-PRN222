using BusinessLogic.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public void SaveTeam(Team team) => TeamDAO.SaveTeam(team);

        public void UpdateTeam(Team team) => TeamDAO.UpdateTeam(team);

        public void DeleteTeam(int id) => TeamDAO.DeleteTeam(id);

        public List<Team> GetAllTeams() => TeamDAO.GetAllTeams();

        public Team? GetTeamById(int id) => TeamDAO.GetTeamById(id);
    }
}
