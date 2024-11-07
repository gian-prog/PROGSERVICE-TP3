using Microsoft.EntityFrameworkCore;
using TP3__FlappyBirb.Data;
using TP3__FlappyBirb.Models;

namespace TP3__FlappyBirb.Services
{
    public class ScoreTP3service
    {
        private readonly TP3__FlappyBirbContext _context;

        public ScoreTP3service(TP3__FlappyBirbContext context)
        {
            _context = context;
        }
        //Créer un score et l'ajouter à la base de données
        public async Task<Scores?> CreateScoresAsync (Scores score)
        {
            if (!IsScoreValid())
            {
                throw new InvalidOperationException("Le contexte de la base de données est invalide.");
            }
            _context.Scores.Add(score);
            await _context.SaveChangesAsync();
            return score;
        }
        //Récupère un score pas son Id
        public async Task<Scores?> GetScoreByIdAsync(int id)
        {
            return await _context.Scores.Where(x => x.Id == id).FirstAsync();
        }

        // Vérifier si un score existe
        public bool ScoreExists(int id)
        {
            return _context.Scores.Any(e => e.Id == id);
        }

        // Mettre à jour la visibilité du score
        public async Task ScoreVisibiliteAsync(Scores score)
        {
            score.Visibilite = !score.Visibilite;
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ScoreDTO>> GetPublicScoresAsync()
        {
            if(!IsScoreValid())
            {
                throw new InvalidOperationException("Le contexte ou la table Scores est inaccessible.");
            }
            // Récupérer les scores avec Visibilite = true, ordonnés par Score et limités à 10
            var scores = await _context.Scores
                .Where(x => x.Visibilite == true)
                .OrderByDescending(x => x.Score)
                .Take(10)
                .ToListAsync();
            // Mapper les scores
            return scores
                .Where(c => c.User != null)
                .Select(c => new ScoreDTO
                {
                    Id = c.Id,
                    Score = c.Score,
                    Temps = c.Temps,
                    Date = c.Date,
                    Visibilite = c.Visibilite,
                    Pseudo = c.User!.UserName
                });
        }
        public bool IsScoreValid()
        {
            return _context != null || _context?.Scores != null;
        }

    }
}
