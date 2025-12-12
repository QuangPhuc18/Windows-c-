using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example01
{
    public partial class Bai5 : Form
    {
        public Bai5()
        {
            InitializeComponent();
        }
        private void Form1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"D:\Key_Logger.txt", true);
            sw.Write(e.KeyCode);
            sw.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void bt_OK_Click(object sender, EventArgs e)
        {

        }

    }
}
