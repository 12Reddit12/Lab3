using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    class RPG : IGame
    {
        public RPG()
        {
        }

        public RPG(string name, double processor_Hertz,
            double ram_Count, double video_Ram_Count, double hDD_Space)
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
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = @"RPGAdventurePlus.exe";
            p.Start();
        }
    }
}
