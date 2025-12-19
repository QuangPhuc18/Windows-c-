using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // <--- Bắt buộc thêm dòng này để dùng StreamWriter

namespace Example01
{
    public partial class Bai9 : Form
    {
        public Bai9()
        {
            InitializeComponent();
        }

        // Sự kiện nút Cộng
        private void btCong_Click(object sender, EventArgs e)
        {
            if (tbSoX.Text != "" && tbSoY.Text != "")
            {
                int x = int.Parse(tbSoX.Text);
                int y = int.Parse(tbSoY.Text);
                int kq = x + y;
                // Cộng dồn chuỗi kết quả vào TextBox (xuống dòng bằng \r\n)
                tbKetQua.Text = tbKetQua.Text + x.ToString() + " + " + y.ToString() + " = " + kq.ToString() + "\r\n";
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ số X và Y");
            }
        }

        // Sự kiện nút Nhân
        private void btNhan_Click(object sender, EventArgs e)
        {
            if (tbSoX.Text != "" && tbSoY.Text != "")
            {
                int x = int.Parse(tbSoX.Text);
                int y = int.Parse(tbSoY.Text);
                int kq = x * y;
                // Cộng dồn chuỗi kết quả vào TextBox
                tbKetQua.Text = tbKetQua.Text + x.ToString() + " * " + y.ToString() + " = " + kq.ToString() + "\r\n";
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ số X và Y");
            }
        }

        // Sự kiện nút Lưu
        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // true nghĩa là ghi nối tiếp (append), không xóa nội dung cũ của file
                StreamWriter sw = new StreamWriter("Caculator.txt", true);
                sw.Write(tbKetQua.Text);
                sw.Close();
                MessageBox.Show("Đã lưu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu file: " + ex.Message);
            }
        }

        // Sự kiện nút Thoát
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}