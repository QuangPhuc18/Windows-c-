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
    public partial class Bai21 : Form
    {
        List<Employee> lst;

        public Bai21()
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
            em.Gender = true; // Nam
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

       
        private void Bai21_Load(object sender, EventArgs e)
        {
            lst = GetData();

            // Duyệt danh sách và thêm vào GridView thủ công theo Slide 142
            foreach (Employee em in lst)
            {
                dgvEmployee.Rows.Add(em.Id, em.Name, em.Age, em.Gender);
            }
        }

        // Sự kiện Thêm mới (Slide 143)
        private void btAddNew_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Id = tbId.Text;
            em.Name = tbName.Text;
            em.Age = int.Parse(tbAge.Text);
            em.Gender = ckGender.Checked;

            lst.Add(em);

            dgvEmployee.Rows.Add(tbId.Text, tbName.Text, tbAge.Text, ckGender.Checked);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow != null)
            {
                int idx = dgvEmployee.CurrentCell.RowIndex;
                dgvEmployee.Rows.RemoveAt(idx);
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0 && dgvEmployee.Rows[idx].Cells[0].Value != null)
            {
                tbId.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();
                tbName.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();
                tbAge.Text = dgvEmployee.Rows[idx].Cells[2].Value.ToString();

                if (dgvEmployee.Rows[idx].Cells[3].Value != null)
                    ckGender.Checked = (bool)dgvEmployee.Rows[idx].Cells[3].Value;
            }
        }
    }
}