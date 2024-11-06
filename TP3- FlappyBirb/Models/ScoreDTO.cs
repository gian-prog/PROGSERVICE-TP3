using System.ComponentModel.DataAnnotations;

namespace TP3__FlappyBirb.Models
{
    public class ScoreDTO
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public double Temps { get; set; }
        public DateTime? Date { get; set; }
        public bool Visibilite { get; set; }
        public string Pseudo { get; set; } = null!;

    }
}
