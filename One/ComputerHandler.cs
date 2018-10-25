using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    class ComputerHandler
    {

        public static void Transport(string saverType)
        {
            Computer computer = new Computer();
            computer.DoTranport(new DataSaverClass.MP3Class());
            computer.DoTranport(new DataSaverClass.UCardClass());
        }
    }
}
