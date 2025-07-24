using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TeamDAO
    {
        public static List<Team> GetAllTeams()
        {
            using var db = new InnocodeDbContext();
            return db.Teams.Include(t => t.Leader).Include(t => t.Projects).ToList();
        }

        public static Team? GetTeamById(int id)
        {
            using var db = new InnocodeDbContext();
            return db.Teams.Include(t => t.Leader).Include(t => t.Projects)
                           .FirstOrDefault(t => t.Id == id);
        }

        public static void SaveTeam(Team team)
        {
            try
            {
                using var db = new InnocodeDbContext();
                db.Teams.Add(team);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateTeam(Team team)
        {
            try
            {
                using var db = new InnocodeDbContext();
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteTeam(int id)
        {
            try
            {
                using var db = new InnocodeDbContext();
                var team = db.Teams.FirstOrDefault(t => t.Id == id);
                if (team != null)
                {
                    db.Teams.Remove(team);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
