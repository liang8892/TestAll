using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.DataSaverClass
{
    class SuperStorageAdapter : IDataSaver
    {
        private SuperStorage _super = new SuperStorage();

        public void Read()
        {
            _super.RT();
        }

        public void Write()
        {
            _super.WT();
        }
    }
}
