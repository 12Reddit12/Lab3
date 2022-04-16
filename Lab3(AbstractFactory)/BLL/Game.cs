using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    abstract class Game
    {

        public string Name;
        public double Processor_Hertz;
        public double Ram_Count;
        public double Video_Ram_Count;
        public double HDD_Space;

        protected Game(string name, double processor_Hertz, double ram_Count, double video_Ram_Count, double hDD_Space)
        {
            Name = name;
            Processor_Hertz = processor_Hertz;
            Ram_Count = ram_Count;
            Video_Ram_Count = video_Ram_Count;
            HDD_Space = hDD_Space;
        }

        public abstract void Play();
        public abstract void Interact();



    }


}
