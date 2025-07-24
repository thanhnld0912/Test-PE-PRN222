using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITeamService
    {
        void SaveTeam(Team team);
        void UpdateTeam(Team team);
        void DeleteTeam(int id);
        List<Team> GetAllTeams();
        Team? GetTeamById(int id);
    }
}
