using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.DataSaverClass
{
    class SuperStorageAdapter : IDataSaver
    {
        private SuperStorage _super;

        public SuperStorage Super
        {
            get { return _super; }
            set { _super = value; }
        }

        public SuperStorageAdapter() { }

        public SuperStorageAdapter(SuperStorage super)
        {
            _super = super;
        }

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
