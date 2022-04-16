using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL;
using Lab3;

namespace BLL
{
    abstract class AbstractComputer
    {
        public abstract void Deliver();
    }
    [Serializable]
    class Computer : AbstractComputer
    {

        public double comp_Processor_Hertz { get; set; }
        public double comp_Ram_Count { get; set; }
        public double comp_Video_Ram_Count { get; set; }
        public double comp_HDD_Space { get; set; }

        public bool comp_Browser { get; set; }
        public bool comp_Internet { get; set; }

        private List<IGame> installed = new List<IGame>();


        private GameDev publisher;



        public Computer(GameDev publisher, double comp_Processor_Hertz, double comp_Ram_Count, double comp_Video_Ram_Count, double comp_HDD_Space,
             bool comp_Browser, bool comp_Internet)
        {
            this.comp_Processor_Hertz = comp_Processor_Hertz;
            this.comp_Ram_Count = comp_Ram_Count;
            this.comp_Video_Ram_Count = comp_Video_Ram_Count;
            this.comp_HDD_Space = comp_HDD_Space;
            this.comp_Browser = comp_Browser;
            this.comp_Internet = comp_Internet;
            publisher = new GameDev();
            this.publisher = publisher;

            Actions.GamesAdd(this);

        }
        public List<IGame> GetInstalled(Computer c)
        {
            return c.installed;
        }

        public override void Deliver()
        {
            foreach (var g in publisher.Games)
            {
                Console.WriteLine(g.GetType().Name + " " + g.Name);
            }
            Console.WriteLine();
        }
    }

}
