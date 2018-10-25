using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using One.DataSaverClass;

namespace One
{
    class Computer
    {
        private IDataSaver _dataSaver;

        public IDataSaver Saver
        {
            get { return _dataSaver; }
            set { _dataSaver = value; }
        }

        public Computer()
        {
        }

        public Computer(IDataSaver saver)
        {
            _dataSaver = saver;
        }

        public void DoTranport()
        {
            _dataSaver.Read();
            _dataSaver.Write();
        }
    }
}
