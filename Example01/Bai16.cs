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
    public partial class Bai16 : Form
    {
        // Biến đếm số thứ tự sinh viên (như trong hình Slide 112: 1. Nguyễn Văn Rột, 2. Trần Thị Học Lai)
        int count = 0;

        public Bai16()
        {
            InitializeComponent();
        }

        // Sự kiện khi bấm nút Thêm
        private void btAdd_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu nhập (đơn giản)
            if (tbName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                return;
            }

            // 2. Tăng số thứ tự
            count++;

            // 3. Lấy giới tính
            string gender = "Nữ"; // Mặc định
            if (rbMale.Checked == true)
            {
                gender = "Nam";
            }

            // 4. Lấy khoa
            string faculty = "";
            if (cbFaculty.SelectedItem != null)
            {
                faculty = cbFaculty.SelectedItem.ToString();
            }

            // 5. Tạo chuỗi kết quả giống y hệt mẫu trong Slide 112
            // Mẫu: 
            // 1. Nguyễn Văn A
            //    -Giới tính: Nam
            //    -Ngày Sinh: 20/10/1995
            //    -Khoa: Công nghệ thông tin

            string result = count.ToString() + ". " + tbName.Text + "\r\n"
                          + "   -Giới tính: " + gender + "\r\n"
                          + "   -Ngày Sinh: " + dtpDob.Value.ToShortDateString() + "\r\n"
                          + "   -Khoa: " + faculty + "\r\n"
                          + "\r\n"; // Thêm dòng trống ngăn cách

            // 6. Cộng dồn vào ô hiển thị (append)
            tbDisplay.Text += result;

            // (Tùy chọn) Xóa tên để nhập người tiếp theo
            // tbName.Clear();
            // tbName.Focus();
        }

        // Sự kiện nút Thoát
        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Load Form: Chọn mặc định cho ComboBox (để đẹp giao diện)
        private void Bai16_Load(object sender, EventArgs e)
        {
            if (cbFaculty.Items.Count > 0)
                cbFaculty.SelectedIndex = 0;

            rbMale.Checked = true; // Mặc định chọn Nam
        }
    }
}