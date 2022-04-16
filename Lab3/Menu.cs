using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using System.Threading;
namespace Lab3
{
    class Menu
    {
        Player player = new Player();

        public void Show_Menu()
        {
            if (player == null)
            {
                player = new Player();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Выбери компьютер:");

            int i = 0;
            foreach (var item in player.players_computers)
            {
                Console.WriteLine($"{i++} - Процессор: {item.comp_Processor_Hertz} Ггц ; HDD: {item.comp_HDD_Space}; RAM: {item.comp_Ram_Count} GB; VIDEO: {item.comp_Video_Ram_Count} GB RAM");
            }

            string str = Console.ReadLine();
            try
            {
                int input = Convert.ToInt32(str);
                var comp = player.players_computers.ElementAt(input);

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("1 - Установить игру");
                    Console.WriteLine("2 - Удалить игру");
                    Console.WriteLine("3 - Запустить игру");
                    Console.WriteLine("4 - Назад");


                    string switcher = Console.ReadLine();
                    switch (switcher)
                    {
                        case "1":

                            if (comp.Install_Game(comp.downloaded.ElementAt(ChooseGameInstalling(comp)), comp) == true)
                            {
                                Thread.Sleep(2000);

                            }

                            break;
                        case "2":
                            if (comp.installed.Count == 0)
                            {
                                Console.WriteLine("Установите игры!");
                                Thread.Sleep(2000);
                                break;
                            }
                            if (comp.Uninstall_Game(comp.installed.ElementAt(ChooseGameDelete(comp)), comp) == false)
                            {
                                Thread.Sleep(2000);
                                Console.WriteLine("RPG нельзя удалить!");
                            }
                            break;

                        case "3":
                            if (comp.installed.Count == 0)
                            {
                                Console.WriteLine("Установите игры!");
                                Thread.Sleep(2000);
                                break;
                            }
                            else
                            {
                                Run(comp).Play();
                            }
                            break;

                        case "4":
                            Show_Menu();
                            break;
                    }

                }
            }
            catch (FormatException)
            {
                Show_Menu();
            }

        }

        IGame Run(Computer comp)
        {
            Console.WriteLine("Какую игру запустить?");
            int i = 0;
            foreach (var item in comp.installed)
            {
                Console.WriteLine($"{i++} - Название: " + item.Name);
            }
            while (true)
            {
                try
                {
                    string game = Console.ReadLine();
                    int i_game = Int32.Parse(game);

                    var selected_game = comp.installed.ElementAt(i_game);
                    return selected_game;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неправильный ввод!");
                }
                catch (ArgumentOutOfRangeException)
                {

                }
            }
        }

        int ChooseGameInstalling(Computer comp)
        {
            Console.WriteLine("Какую игру установить ?");
            int i = 0;
            foreach (var item in comp.downloaded)
            {
                Console.WriteLine($"{i++} - Название: " + item.Name);
            }

            string str2 = Console.ReadLine();
            int input2 = Convert.ToInt32(str2);

            return input2;
        }

        int ChooseGameDelete(Computer comp)
        {
            Console.WriteLine("Какую игру удалить ?");
            int i = 0;
            foreach (var item in comp.installed)
            {
                Console.WriteLine($"{i++} - Название: " + item.Name);
            }

            string str2 = Console.ReadLine();
            int input2 = Convert.ToInt32(str2);

            return input2;
        }

    }
}
