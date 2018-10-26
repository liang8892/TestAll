using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class BUser
    {
        private IDBHelper _dbHelper;

        public IDBHelper DbHelper
        {
            get { return _dbHelper; }
            set { _dbHelper = value; }
        }

        public BUser()
        {
        }

        public BUser(IDBHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }


        public List<string> GetAllUser()
        {
            List<string> users = new List<string>();
            DataSet ds = _dbHelper.Query("select username from tb_userinfo where userid>1300");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    users.Add(row["username"].ToString());
                }
            }
            return users;
        }

    }
}
