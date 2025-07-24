using BusinessLogic.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;

        public TeamService()
        {
            teamRepository = new TeamRepository();
        }

        public void SaveTeam(Team team) => teamRepository.SaveTeam(team);

        public void UpdateTeam(Team team) => teamRepository.UpdateTeam(team);

        public void DeleteTeam(int id) => teamRepository.DeleteTeam(id);

        public List<Team> GetAllTeams() => teamRepository.GetAllTeams();

        public Team? GetTeamById(int id) => teamRepository.GetTeamById(id);
    }
}
