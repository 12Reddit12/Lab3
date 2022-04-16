using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class Factory : AbstractDev
    {
        public Factory()
        {
            Games = new List<Game>();
            CreateGame();

        }
        public List<Game> Games { get; set; }

        public override List<Game> CreateGame()
        {
            Games = new List<Game>();
            Games.Add(new Adventures("Adventures", 3, 4, 1, 50));
            Games.Add(new Strategy("Strategy", 2, 2, 2, 50));
            Games.Add(new RPG("RPG", 1, 1, 0.1, 0.5));
            return Games;
        }

    }
}
