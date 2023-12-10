using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberSolid.BLL.Interfaces
{
    public interface ISettingsService
    {
        public void SaveSettings(Settings settings);
        public Settings GetSettings();
    }
}
