using GuessNumberSolid.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GuessNumberSolid.BLL;
using GuessNumberSolid.BLL.Interfaces;

namespace GuessNumberSolid.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISettingsService _settingsService;
        private readonly IGameService _gameService;

        public HomeController(ISettingsService settingsService, IGameService gameService)
        {
            _settingsService = settingsService;
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SaveSettings(SettingsViewModel userSettings)
        {
            Settings settings = new()
            {
                MaxValue = userSettings.MaxValue,
                MinValue = userSettings.MinValue,
                Attempts = userSettings.Attempts
            };
            _settingsService.SaveSettings(settings);
            _gameService.StartGame();
            return RedirectToAction("Game", "Game");
        }
    }
}
