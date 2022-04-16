using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    class Strategy : IGame
    {
        public Strategy()
        {
        }

        public Strategy(string name, double processor_Hertz,
            double ram_Count,
            double video_Ram_Count, double hDD_Space)
        {
            Name = name;
            Processor_Hertz = processor_Hertz;
            Ram_Count = ram_Count;
            Video_Ram_Count = video_Ram_Count;
            HDD_Space = hDD_Space;
        }

        public string Name { get; set; }
        public double Processor_Hertz { get; set; }
        public double Ram_Count { get; set; }
        public double Video_Ram_Count { get; set; }
        public double HDD_Space { get; set; }



        public void Play()
        {

            Man man = new Man();
            Orc orc = new Orc();
            Console.WriteLine("Game start");

            Console.ReadKey();
            Console.WriteLine("Damage to player");
            man.SetDamage(orc, 50);

            Console.ReadKey();
            Console.WriteLine("Damage enemy");
            orc.SetDamage(man, 100);
            Console.ReadKey();
            Console.WriteLine("Damage to player");
            man.SetDamage(orc, 50);
            Console.ReadKey();

        }

        public abstract class Character
        {
            public int Health { get; private set; }

            public Character()
            {
                Health = 100;
            }

            public virtual void GetDamage(int damage)
            {
                Health -= damage;
                if (Health < 1)
                {
                    Console.WriteLine("Персонаж погиб");
                }
            }

            public void SetDamage(Character character, int damage)
            {
                character.GetDamage(damage);
            }
        }

        public class Man : Character
        {
            public override void GetDamage(int damage)
            {
                Console.WriteLine($"Человек получил урон: {damage}");
                base.GetDamage(damage);
            }
        }

        public class Orc : Character
        {
            public override void GetDamage(int damage)
            {
                Console.WriteLine($"Орк получил урон: {damage}");
                base.GetDamage(damage);
            }
        }



    }

}
