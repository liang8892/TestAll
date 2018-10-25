using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.DataSaverClass
{
    class HardDisk:IDataSaver
    {
        public void Read()
        {
            Console.WriteLine("硬盘Read");
        }

        public void Write()
        {
            Console.WriteLine("硬盘Write");
        }
    }
}
