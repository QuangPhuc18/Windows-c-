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
    public partial class Bai14 : Form
    {
        public Bai14()
        {
            InitializeComponent();
        }

        // Sự kiện nút Tính tiền (Code y hệt Slide 106)
        private void btRun_Click(object sender, EventArgs e)
        {
            string msg = null;
            int disc = 0;

            if (rbMale.Checked == true)
                msg += "Ông ";

            if (rbFemale.Checked == true)
                msg += "Bà ";

            // Logic tính giảm giá theo Slide 106 (cố định là 5)
            if (ckDiscount.Checked == true)
            {
                disc = 5;
                // Nếu muốn lấy giá trị từ ô nhập liệu thay vì số 5 cố định, 
                // bạn có thể đổi thành: disc = int.Parse(tbDiscount.Text);
            }

            tbResult.Text = msg + tbName.Text + " được giảm " + disc.ToString() + "%" + "\r\n";
        }

        // Sự kiện khi tích vào ô Giảm giá (Code y hệt Slide 106)
        private void ckDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDiscount.Checked == true)
                tbDiscount.Enabled = true;
            else
                tbDiscount.Enabled = false;
        }

        // Sự kiện nút Thoát
        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}