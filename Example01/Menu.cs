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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button01_Click(object sender, EventArgs e)
        {
            Bai1 form = new Bai1();
            form.Show();
        }

        private void btn_example01_Click(object sender, EventArgs e)
        {
            Bai3 form2 = new Bai3();
            form2.Show();
        }
        private void btn_05_Click(object sender, EventArgs e)
        {
            Bai5 form3 = new Bai5();
            form3.Show();
        }
        private void btn_06_Click(object sender, EventArgs e)
        {
            Bai6 form6 = new Bai6();
            form6.Show();
        }
        private void btn_07_Click(object sender, EventArgs e)
        {
            Bai7 form7 = new Bai7();
            form7.Show();
        } 
        private void btn_08_Click(object sender, EventArgs e)
        {
            Bai8 form = new Bai8();
            form.Show();
        }
        private void Menu_Load(object sender, EventArgs e)
        {

        }

       
    }
}
