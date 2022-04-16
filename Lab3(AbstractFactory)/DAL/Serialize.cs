using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Serialize
    {
        public static void Serialize_System(object o)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            File.Create("Serial.txt").Dispose();
            using (FileStream sw = new FileStream("Serial.txt", FileMode.Create))
            {
                formatter.Serialize(sw, o);
            }
        }

        public static object Deserialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists("Serial.txt"))
            {
                using (FileStream fs = new FileStream("Serial.txt", FileMode.OpenOrCreate))
                {


                    return formatter.Deserialize(fs);

                }
            }
            else
            {
                return null;
            }

        }
    }

}
