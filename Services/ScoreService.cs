using BusinessLogic.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository scoreRepository;

        public ScoreService()
        {
            scoreRepository = new ScoreRepository();
        }

        public void SaveScore(Score score) => scoreRepository.SaveScore(score);

        public void UpdateScore(Score score) => scoreRepository.UpdateScore(score);

        public void DeleteScore(int id) => scoreRepository.DeleteScore(id);

        public List<Score> GetScoresByProjectId(int projectId) => scoreRepository.GetScoresByProjectId(projectId);

        public Score? GetScoreById(int id) => scoreRepository.GetScoreById(id);
    }
}
