using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class ComboxTest : Form
    {
        public ComboxTest()
        {
            InitializeComponent();

            List<string> strs = new List<string>();
            comboBox1.Items.AddRange(strs.ToArray());

            MessageBox.Show("OK");
        }
    }
}
