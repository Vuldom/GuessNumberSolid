using GuessNumberSolid.BLL.Interfaces;


namespace GuessNumberSolid.BLL.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly Storage _storage;
        public SettingsService(Storage storage) 
        {
            _storage = storage;
        }
        public void SaveSettings(Settings settings)
        {
            _storage.Settings = settings;
        }

        public Settings GetSettings()
        {
            return _storage.Settings;
        }
    }
}
