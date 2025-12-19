using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Example01
{
    public partial class Bai20 : Form
    {
        public Bai20()
        {
            InitializeComponent();
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {
            dgvEmployee.Rows.Add(tbId.Text, tbName.Text, tbAge.Text, ckGender.Checked);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            int idx = dgvEmployee.CurrentCell.RowIndex;
            dgvEmployee.Rows.RemoveAt(idx);
        }

        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (dgvEmployee.Rows[idx].Cells[0].Value != null)
            {
                tbId.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();
                tbName.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();
                tbAge.Text = dgvEmployee.Rows[idx].Cells[2].Value.ToString();
                ckGender.Checked = bool.Parse(dgvEmployee.Rows[idx].Cells[3].Value.ToString());
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}