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
    public partial class Bai7 : Form
    {
        public Bai7()
        {
            InitializeComponent();
        }
        private void tbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }
        private void tbYear_Validating(object sender, CancelEventArgs e)
        {
            int year = int.Parse(tbYear.Text);
            if (year > 2000)
            {
                e.Cancel = true;
            }

        }
      
    }
}
