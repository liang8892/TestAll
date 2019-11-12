using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> inputLines1 = File.ReadAllLines(tb_input1.Text, Encoding.Default).ToList();
            List<string> inputLines2 = File.ReadAllLines(tb_input2.Text, Encoding.Default).ToList();
            List<string> outputLines = new List<string>();
            foreach (string inputLine in inputLines1)
            {
                string s = inputLine.Replace(" ", "");
                if (!inputLines2.Contains(s))
                    outputLines.Add(inputLine);
            }
            File.WriteAllLines(tb_output.Text, outputLines, Encoding.Default);
            MessageBox.Show("完成！");
        }

        private void textBox_DragEnter(object sender, DragEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Text = ((Array) (e.Data.GetData(DataFormats.FileDrop))).GetValue(0).ToString();
        }

        private void textBox_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Link : DragDropEffects.None;
        }

    }
}
