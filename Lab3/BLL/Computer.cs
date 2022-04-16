using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    [Serializable]
    public class Computer
    {
        public double comp_Processor_Hertz { get; set; }
        public double comp_Ram_Count { get; set; }
        public double comp_Video_Ram_Count { get; set; }
        public double comp_HDD_Space { get; set; }

        public bool Wheel { get; set; }
        public bool comp_Browser { get; set; }
        public bool comp_Internet { get; set; }



        public delegate void ComputerDelgate(object sender, string e);
        public event ComputerDelgate Game_Installed_or_Not;
        public event ComputerDelgate Game_UnInstalled;
        public event ComputerDelgate Game_is_Installing;


        public List<IGame> downloaded = new List<IGame>();
        public List<IGame> installed = new List<IGame>();



        public bool GamesAdd()
        {
            if (downloaded.Count <= 0)
            {
                downloaded.Add(new Adventures("Try Survive", 3, 4, 1, 50));
                downloaded.Add(new Strategy("WarCraft", 2, 2, 2, 50));

                Serialize_System();
                return true;
            }
            else
            {
                return false;
            }

        }

        public Computer(double comp_Processor_Hertz, double comp_Ram_Count, double comp_Video_Ram_Count, double comp_HDD_Space,
             bool comp_Browser, bool comp_Internet)
        {
            this.comp_Processor_Hertz = comp_Processor_Hertz;
            this.comp_Ram_Count = comp_Ram_Count;
            this.comp_Video_Ram_Count = comp_Video_Ram_Count;
            this.comp_HDD_Space = comp_HDD_Space;
            this.comp_Browser = comp_Browser;
            this.comp_Internet = comp_Internet;
            GamesAdd();
            if (this.comp_Browser == true && this.comp_Internet == true)
            {
                installed.Add(new RPG("RPG", 1, 1, 0.1, 0.5));
                Serialize_System();
            }

        }

        public Computer()
        {
        }

        public bool Install_Game(IGame game, Computer comp)
        {
            if (comp.installed.Any(o => game.Name == o.Name))
            {
                return false;
            }
            else
            {

                if ((comp.comp_HDD_Space > game.HDD_Space) && (comp.comp_Processor_Hertz >= game.Processor_Hertz) &&
                    comp.comp_Ram_Count >= game.Ram_Count && comp.comp_Video_Ram_Count >= game.Video_Ram_Count)
                {

                    comp.installed.Add(game);
                    comp.comp_HDD_Space -= game.HDD_Space;

                    comp.Game_Installed_or_Not += Computer_Game_Event;
                    comp.Game_is_Installing += Computer_Game_Event;

                    Comp_Game_is_Installing(this,  "");
                    Game_Installed_or_Not(this,"Игра установлена!");

                    Serialize_System();
                    return true;

                }
                else
                {
                    comp.Game_Installed_or_Not += Computer_Game_Event;
                    Game_Installed_or_Not(this, "Игра не установлена!");
                    Serialize_System();
                    return false;
                }
            }

        }

        private void Comp_Game_is_Installing(object sender, string e)
        {
            for (int i = 0; i < 25; i++)
            {
                Console.Write("|");
                Thread.Sleep(100);
            }
        }

        public bool Uninstall_Game(IGame game, Computer comp)
        {

            var t = comp.installed.Where(o => o.Name == game.Name).FirstOrDefault();

            if (t.Name == "Casino")
            {
                return false;
            }

            if (t != null)
            {
                comp.installed.Remove(t);
                Game_UnInstalled += Computer_Game_Event;
                Game_UnInstalled(this, "Игра удалена!");

                Serialize_System();

                return true;
            }
            else
            {

                return false;
            }

        }


        public bool Serialize_System()
        {
            Serialize.Serialize_System(this);
            return true;
        }

        private void Computer_Game_Event(object sender, string e)
        {
            Console.WriteLine('\n' + e);
        }


    }

}
