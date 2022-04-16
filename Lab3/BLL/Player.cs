using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    [Serializable]

    class Player
    {
        List<Computer> players_computers = new List<Computer>();
        GameDev developer = new GameDev();


        public Player()
        {
            if (players_computers.Count == 0)
            {
                players_computers.Add(new Computer(developer, 3.1, 8, 2, 500, true, true));
                players_computers.Add(new Computer(developer, 2.5, 4, 1, 250, true, true));
                players_computers.Add(new Computer(developer, 1.6, 2, 0.512, 60, false, true));

            }

            foreach (var item in players_computers)
            {
                developer.AddToClientList(item);

            }

            developer.SendGameToClient();
        }

        public List<Computer> GetComputers()
        {
            return players_computers;
        }



    }


}
