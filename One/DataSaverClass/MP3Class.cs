using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.DataSaverClass
{
    class MP3Class:IDataSaver
    {
        public void Read()
        {
            Console.WriteLine("MP3 Read");
        }

        public void Write()
        {
            Console.WriteLine("MP3 Write");
        }

        public void Play()
        {
            
        }
    }
}
