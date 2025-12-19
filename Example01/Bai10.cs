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
    public partial class Bai10 : Form
    {
        decimal workingMemory = 0;
        string opr = "";

        public Bai10()
        {
            InitializeComponent();
        }

      

        private void bt0_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += bt0.Text;
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += bt1.Text;
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += bt2.Text;
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += bt3.Text;
        }

        private void btDot_Click(object sender, EventArgs e)
        {
          
            if (!tbDisplay.Text.Contains("."))
            {
                tbDisplay.Text += btDot.Text;
            }
        }

      

        private void btPlus_Click(object sender, EventArgs e)
        {
            if (tbDisplay.Text != "")
            {
                opr = btPlus.Text; 
                workingMemory = decimal.Parse(tbDisplay.Text);
                tbDisplay.Clear(); 
            }
        }

        private void btMul_Click(object sender, EventArgs e)
        {
            if (tbDisplay.Text != "")
            {
                opr = btMul.Text; 
                workingMemory = decimal.Parse(tbDisplay.Text);
                tbDisplay.Clear();
            }
        }

        private void btEquals_Click(object sender, EventArgs e)
        {
            if (tbDisplay.Text != "")
            {
                decimal secondValue = decimal.Parse(tbDisplay.Text);

                if (opr == "+")
                {
                    tbDisplay.Text = (workingMemory + secondValue).ToString();
                }

                if (opr == "*")
                {
                    tbDisplay.Text = (workingMemory * secondValue).ToString();
                }
            }
        }
    }
}