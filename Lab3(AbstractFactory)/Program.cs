using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = null;
            client = new Client(new Factory());
            client.Run();

            Menu m = new Menu();
            m.Show_Menu();

        }
    }
}
