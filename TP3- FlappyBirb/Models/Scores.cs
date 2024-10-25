using System.Text.Json.Serialization;

namespace TP3__FlappyBirb.Models
{
    public class Scores
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public double Temps { get; set; }
        public DateTime Date { get; set; }
        public bool Visibilite { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }

    }
}
