using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class Client
    {
        private List<Game> games;

        public Client(AbstractDev developer)
        {
            games = developer.CreateGame();
        }

        public void Run()
        {
            foreach (var item in games)
            {
                item.Interact();
            }
        }
    }

}
