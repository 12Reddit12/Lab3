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


        public Player()
        {
            if (players_computers.Count == 0)
            {
                players_computers.Add(new Computer(3.1, 8, 2, 500, true, true));
                players_computers.Add(new Computer(2.5, 4, 1, 250, true, true));
                players_computers.Add(new Computer(1.6, 2, 0.512, 60, false, true));

            }

        }

        public List<Computer> GetComputers()
        {
            return players_computers;
        }



    }



}
