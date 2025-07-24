using BusinessLogic.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        public void SaveScore(Score score) => ScoreDAO.SaveScore(score);

        public void UpdateScore(Score score) => ScoreDAO.UpdateScore(score);

        public void DeleteScore(int id) => ScoreDAO.DeleteScore(id);

        public List<Score> GetScoresByProjectId(int projectId) => ScoreDAO.GetScoresByProjectId(projectId);

        public Score? GetScoreById(int id) => ScoreDAO.GetScoreById(id);
    }
}
