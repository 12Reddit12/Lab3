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

    public class Player
    {
        public List<Computer> players_computers = new List<Computer>();


        public Player()
        {
            if (players_computers.Count == 0)
            {
                players_computers.Add(new Computer(3.1, 8, 2, 500, true, true));
                players_computers.Add(new Computer(2.5, 4, 1, 250, true, true));
                players_computers.Add(new Computer(1.6, 2, 0.512, 60, false, true));
                Serialize.Serialize_System(this);

            }

        }

        public Player(List<Computer> players_computers)
        {
            this.players_computers = players_computers;
        }

        public bool ComputerAdd()
        {
            if (players_computers.Count == 0)
            {
                players_computers.Add(new Computer(3.1, 8, 2, 500, true, true));
                players_computers.Add(new Computer(2.5, 4, 1, 250, true, true));
                players_computers.Add(new Computer(1.6, 2, 0.512, 60, false, true));
                return true;
            }
            else
            {
                return false;
            }

        }

    }

}
