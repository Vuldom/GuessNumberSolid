using GuessNumberSolid.BLL;

namespace GuessNumberSolid.Models
{
    public class GameViewModel
    {
        public Settings LastSettings { get; set; }
        public int AttemptsLeft { get; set; }
        public int? UserAnswer {  get; set; }
        public string Hint { get; set; }
        public bool IsWinner { get; set; }
    }
}
