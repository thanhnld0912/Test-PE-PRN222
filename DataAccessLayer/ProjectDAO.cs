using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProjectDAO
    {
        public static List<Project> GetAllProjects()
        {
            using var db = new InnocodeDbContext();
            return db.Projects.Include(p => p.Team).Include(p => p.Scores).ToList();
        }

        public static Project? GetProjectById(int id)
        {
            using var db = new InnocodeDbContext();
            return db.Projects.Include(p => p.Team).Include(p => p.Scores)
                              .FirstOrDefault(p => p.Id == id);
        }

        public static List<Project> GetProjectsByTeamId(int teamId)
        {
            using var db = new InnocodeDbContext();
            return db.Projects.Where(p => p.TeamId == teamId).ToList();
        }

        public static void SaveProject(Project project)
        {
            try
            {
                using var db = new InnocodeDbContext();
                db.Projects.Add(project);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateProject(Project project)
        {
            try
            {
                using var db = new InnocodeDbContext();
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteProject(int id)
        {
            try
            {
                using var db = new InnocodeDbContext();
                var project = db.Projects.FirstOrDefault(p => p.Id == id);
                if (project != null)
                {
                    db.Projects.Remove(project);
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
