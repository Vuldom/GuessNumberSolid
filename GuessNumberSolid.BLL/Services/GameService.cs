using GuessNumberSolid.BLL.Interfaces;

namespace GuessNumberSolid.BLL.Services
{
    public class GameService : IGameService
    {
        private readonly Storage _storage;
        private readonly ISecretNumberService _secretNumberService;
        public GameService(Storage storage, ISecretNumberService secretNumberService)
        {
            _storage = storage;
            _secretNumberService = secretNumberService;
        }

        public Game StartGame()
        {
            Game game = new Game()
            {
                AttemptsLeft = _storage.Settings.Attempts,
                SecretAnswer = _secretNumberService.GetSecretNumber()
            };
            _storage.CurrentGame = game;
            return game;
        }

        public Game GetGame()
        {
            return _storage.CurrentGame;
        }

        public Game PlayGame(int userAnswer)
        {
            var game = _storage.CurrentGame;
            if(game.SecretAnswer > userAnswer)
            {
                game.AttemptsLeft--;
                game.Hint = "Secret number is bigger";
            }
            else if (game.SecretAnswer < userAnswer)
            {
                game.AttemptsLeft--;
                game.Hint = "Secret number is smaller";
            }
            else
            {
                game.IsWinner = true;
            }
            return game;
        }

    }
}
