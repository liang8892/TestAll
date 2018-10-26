using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using One.DataSaverClass;

namespace One
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Transport("");
        }


        public static void Transport(string saverType)
        {
            Computer computer = new Computer(new MP3Class());
            computer.DoTranport();

            computer.Saver = new UCardClass();
            computer.DoTranport();

            computer.Saver = new HardDisk();
            computer.DoTranport();

            computer.Saver = new SuperStorageAdapter(new SuperStorage());
            computer.DoTranport();
        }
    }
}
