

namespace GuessNumberSolid.BLL
{
    public class Game
    {
        public int AttemptsLeft { get; set; }
        public int SecretAnswer { get; set;}
        public bool IsWinner {  get; set; }
        public string Hint { get; set; }
    }
}
