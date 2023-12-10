using GuessNumberSolid.BLL.Interfaces;


namespace GuessNumberSolid.BLL.Services
{
    public class SecretNumberService : ISecretNumberService
    {
        private readonly ISettingsService _settingsService;
        public SecretNumberService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public int GetSecretNumber()
        {
            var settings = _settingsService.GetSettings();
            Random rnd = new Random();
            return rnd.Next(settings.MinValue, settings.MaxValue);
        }
    }
}
