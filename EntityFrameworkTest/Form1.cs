using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Initial();
        }

        //初始化
        public void Initial()
        {
            UsersEntities usersEntities = new UsersEntities();

            tb_userinfo userinfo = usersEntities.tb_userinfo.Find(986);
            tb_Name.Text = userinfo.Username;
            tb_Limit.Text = userinfo.Limit;
            tb_ID.Text = userinfo.UserID.ToString();

            //usersEntities.SaveChanges();

            //tb_XXUser xXUser = userinfo.tb_XXUser.FirstOrDefault();

        }
    }
}
