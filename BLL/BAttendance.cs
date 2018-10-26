using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    class BAttendance
    {
        private IDBHelper _dbHelper;

        public IDBHelper DbHelper
        {
            get { return _dbHelper; }
            set { _dbHelper = value; }
        }

        public BAttendance()
        {
        }

        public BAttendance(IDBHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }



    }
}
