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
    public partial class Bai22 : Form
    {
        List<Employee> lstEmp;
        BindingSource bs = new BindingSource();

        public Bai22()
        {
            InitializeComponent();
        }

        public List<Employee> GetData()
        {
            List<Employee> lst = new List<Employee>();

            Employee em = new Employee();
            em.Id = "53418";
            em.Name = "Sơn Tùng MTP";
            em.Age = 20;
            em.Gender = true;
            lst.Add(em);

            em = new Employee();
            em.Id = "53416";
            em.Name = "Hoàng Dũng";
            em.Age = 25;
            em.Gender = true;
            lst.Add(em);

            em = new Employee();
            em.Id = "53417";
            em.Name = "Nguyễn Hào";
            em.Age = 23;
            em.Gender = true;
            lst.Add(em);

            return lst;
        }

        private void Bai22_Load(object sender, EventArgs e)
        {
            lstEmp = GetData();
            bs.DataSource = lstEmp;
            dgvEmployee.DataSource = bs;
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Id = tbId.Text;
            em.Name = tbName.Text;
            em.Age = int.Parse(tbAge.Text);
            em.Gender = ckGender.Checked;

            lstEmp.Add(em);
            bs.Add(em);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            int idx = dgvEmployee.CurrentCell.RowIndex;
            bs.RemoveAt(idx);
            lstEmp.RemoveAt(idx);
        }

        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0 && idx < dgvEmployee.Rows.Count && dgvEmployee.Rows[idx].Cells[0].Value != null)
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