using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFacTestDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            //System.Xml.Serialization.XmlSerializer xmlSerializer =
            //    new System.Xml.Serialization.XmlSerializer(typeof(string));
            //tb_out.Text = xmlSerializer.Serialize()

            DataTable dt = new DataTable();

            var dt2 = dt;
        }
    }
}
