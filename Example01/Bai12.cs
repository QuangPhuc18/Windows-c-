using System;
using System.Collections; // Bắt buộc để dùng ArrayList (Slide 100)
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example01
{
    // Lưu ý: Tên class là Bai12 để khớp với lỗi của bạn
    public partial class Bai12 : Form
    {
        public Bai12()
        {
            InitializeComponent();
        }

        // 1. Hàm tạo dữ liệu giả lập (Slide 100)
        public ArrayList GetData()
        {
            ArrayList lst = new ArrayList();

            Faculty f = new Faculty();
            f.Id = "K01";
            f.Name = "Công nghệ thông tin";
            f.Quantity = 1200;
            lst.Add(f);

            f = new Faculty();
            f.Id = "K02";
            f.Name = "Quản trị kinh doanh";
            f.Quantity = 4200;
            lst.Add(f);

            f = new Faculty();
            f.Id = "K03";
            f.Name = "Kế toán tài chính";
            f.Quantity = 5200;
            lst.Add(f);

            return lst;
        }

        // 2. Sự kiện Load Form (Slide 101)
        private void Bai12_Load(object sender, EventArgs e)
        {
            ArrayList lst = GetData();
            cb_Faculty.DataSource = lst;
            cb_Faculty.DisplayMember = "Name";
        }

        // 3. Sự kiện SelectedValueChanged (Slide 101)
        // Đây là hàm MỚI, thay thế cho SelectedIndexChanged cũ
        private void cb_Faculty_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_Faculty.SelectedValue != null)
            {
                cb_Faculty.ValueMember = "Id";
                string id = cb_Faculty.SelectedValue.ToString();
                tbDisplay.Text = "Bạn đã chọn khoa có mã : " + id;
            }
        }

        // 4. Sự kiện bấm nút OK
        private void btOK_Click(object sender, EventArgs e)
        {
            cb_Faculty.ValueMember = "Name";
            string name = cb_Faculty.SelectedValue.ToString();
            tbDisplay.Text = "Bạn là sinh viên khoa : " + name;
        }
    }
}