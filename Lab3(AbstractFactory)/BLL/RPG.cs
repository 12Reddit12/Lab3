using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    class RPG : Game
    {
        public RPG(string name, double processor_Hertz, double ram_Count, double video_Ram_Count, double hDD_Space) : base(name, processor_Hertz, ram_Count, video_Ram_Count, hDD_Space)
        {
           
        }

        public override void Interact()
        {
            
        }
        public override void Play()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = @"RPGAdventurePlus.exe";
            p.Start();
        }
    }
}
