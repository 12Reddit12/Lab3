using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BLL;
namespace Lab3
{
    class Actions
    {
        Event actions = new Event();

        public static bool GamesAdd(Computer c)
        {

            if (c.comp_Browser == true && c.comp_Internet == true)
            {
                c.GetInstalled(c).Add(new RPG("RPG", 1, 1, 0.1, 0.5));
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Uninstall_Game(Game game, Computer comp)
        {

            var t = comp.GetInstalled(comp).Where(o => o.Name == game.Name).FirstOrDefault();

            if (t.Name == "RPG")
            {
                actions.ErrorEvent();
                return false;
            }

            if (t != null)
            {
                comp.GetInstalled(comp).Remove(t);
                actions.UninstallEvent();
                return true;
            }
            else
            {
                actions.ErrorEvent();
                return false;
            }

        }

        public bool Install_Game(Game game, Computer comp)
        {
            if (comp.GetInstalled(comp).Any(o => game.Name == o.Name))
            {
                actions.ErrorEvent();
                return false;
            }
            else
            {

                if ((comp.comp_HDD_Space > game.HDD_Space) && (comp.comp_Processor_Hertz >= game.Processor_Hertz) &&
                    comp.comp_Ram_Count >= game.Ram_Count && comp.comp_Video_Ram_Count >= game.Video_Ram_Count)
                {

                    comp.GetInstalled(comp).Add(game);
                    comp.comp_HDD_Space -= game.HDD_Space;
                    actions.InstallEvent();
                    return true;

                }
                else
                {
                    actions.ErrorEvent();
                    return false;
                }
            }

        }
        public bool Play_Game(Game game)
        {
            actions.StartEvent();
            game.Play();
            return true;
        }

    }
}
