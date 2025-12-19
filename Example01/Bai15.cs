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
    public partial class Bai15 : Form
    {
        public Bai15()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.Text = dtpDate.Value.ToLongDateString();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            this.Text = dtpDate.Value.ToShortDateString();
        }
    }
}