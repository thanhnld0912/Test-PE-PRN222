using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IScoreService
    {
        void SaveScore(Score score);
        void UpdateScore(Score score);
        void DeleteScore(int id);
        List<Score> GetScoresByProjectId(int projectId);
        Score? GetScoreById(int id);
    }
}
