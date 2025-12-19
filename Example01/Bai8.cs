using System;
using System.Windows.Forms;

namespace Example01
{
    public partial class Bai8 : Form
    {
        public Bai8()
        {
            InitializeComponent();
        }

        private bool LayGiaTri(out int x, out int y)
        {
            x = 0;
            y = 0;

            if (!int.TryParse(tbSoX.Text, out x))
            {
                MessageBox.Show("Vui lòng nhập số X hợp lệ!");
                tbSoX.Focus();
                return false;
            }

            if (!int.TryParse(tbSoY.Text, out y))
            {
                MessageBox.Show("Vui lòng nhập số Y hợp lệ!");
                tbSoY.Focus();
                return false;
            }

            return true;
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            if (LayGiaTri(out int x, out int y))
            {
                tbKetQua.Text = (x + y).ToString();
            }
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (LayGiaTri(out int x, out int y))
            {
                tbKetQua.Text = (x * y).ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
