using GuessNumberSolid.Models;
using Microsoft.AspNetCore.Mvc;
using GuessNumberSolid.BLL.Interfaces;

namespace GuessNumberSolid.Controllers
{
    public class GameController : Controller
    {
        private readonly ISettingsService _settingsService;
        private readonly IGameService _gameService;
        public GameController(ISettingsService settingsService, IGameService gameService)
        {
            _settingsService = settingsService;
            _gameService = gameService;
        }

        public ActionResult Game()
        {
            var settings = _settingsService.GetSettings();
            var game = _gameService.GetGame();
            GameViewModel gameViewModel = new()
            {
                LastSettings = settings,
                AttemptsLeft = game.AttemptsLeft,
                IsWinner = game.IsWinner,
                Hint = game.Hint

            };
            return View(gameViewModel);
        }

        [HttpPost]
        public IActionResult VerifyAnswer(GameViewModel gameViewModel)
        {
            int answer = gameViewModel.UserAnswer.Value;
            _gameService.PlayGame(answer);
            return RedirectToAction("Game");
        }
      
    }
}
