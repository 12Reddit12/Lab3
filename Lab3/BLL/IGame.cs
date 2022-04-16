using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IGame
    {
        string Name { get; set; }
        double Processor_Hertz { get; set; }
        double Ram_Count { get; set; }
        double Video_Ram_Count { get; set; }
        double HDD_Space { get; set; }
        void Play();

    }

}
