using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ScoreDAO
    {
        public static List<Score> GetScoresByProjectId(int projectId)
        {
            using var db = new InnocodeDbContext();
            return db.Scores.Include(s => s.Lecturer).Where(s => s.ProjectId == projectId).ToList();
        }

        public static Score? GetScoreById(int id)
        {
            using var db = new InnocodeDbContext();
            return db.Scores.Include(s => s.Lecturer).Include(s => s.Project)
                            .FirstOrDefault(s => s.Id == id);
        }

        public static void SaveScore(Score score)
        {
            try
            {
                using var db = new InnocodeDbContext();
                db.Scores.Add(score);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateScore(Score score)
        {
            try
            {
                using var db = new InnocodeDbContext();
                db.Entry(score).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteScore(int id)
        {
            try
            {
                using var db = new InnocodeDbContext();
                var score = db.Scores.FirstOrDefault(s => s.Id == id);
                if (score != null)
                {
                    db.Scores.Remove(score);
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
