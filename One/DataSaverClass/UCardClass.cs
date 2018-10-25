using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.DataSaverClass
{
    class UCardClass : IDataSaver
    {
        public void Read()
        {
            Console.WriteLine("U盘Read");
        }

        public void Write()
        {
            Console.WriteLine("U盘Write");
        }

    }
}
