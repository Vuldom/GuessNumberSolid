using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberSolid.BLL.Interfaces
{
    public interface IGameService
    {
        Game StartGame();
        Game GetGame();
        Game PlayGame(int userAnswer);
    }
}
