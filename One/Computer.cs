﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    class Computer
    {
        public void DoTranport(IDataSaver saver)
        {
            saver.Read();
            saver.Write();
        }
    }
}
