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
    public partial class Bai11 : Form
    {
        // --- KHAI BÁO BIẾN TOÀN CỤC (Slide 83) ---
        decimal memory = 0;
        decimal workingMemory = 0;
        string opr = "";

        public Bai11()
        {
            // Hàm này bắt buộc phải có để khởi tạo giao diện từ file Designer.cs
            InitializeComponent();
        }

        // --- XỬ LÝ LOGIC CHUNG CHO TẤT CẢ CÁC NÚT (Slide 84 -> 90) ---
        // Tất cả các nút trong file Designer.cs đều được nối sự kiện vào hàm này.
        private void Button_Click(object sender, EventArgs e)
        {
            // Ép kiểu sender về Button để biết nút nào vừa được nhấn
            Button bt = (Button)sender;

            // 1. Nhập số và dấu chấm (Slide 84)
            // Kiểm tra nếu là số (0-9) HOẶC là dấu chấm "."
            if ((char.IsDigit(bt.Text, 0) && bt.Text.Length == 1) || bt.Text == ".")
            {
                // Nếu màn hình đang hiển thị số 0 mặc định thì xóa đi để nhập số mới (trừ khi nhập dấu chấm)
                if (txtDisplay.Text == "0" && bt.Text != ".")
                {
                    txtDisplay.Text = "";
                }

                // Chặn nhập nhiều dấu chấm: Nếu đã có dấu chấm rồi thì không cho nhập thêm
                if (bt.Text == "." && txtDisplay.Text.Contains("."))
                {
                    // Không làm gì cả
                }
                else
                {
                    // Nối thêm số hoặc dấu chấm vào màn hình
                    txtDisplay.Text += bt.Text;
                }
            }
            // 2. Các phép toán cơ bản + - * / (Slide 86)
            else if (bt.Text == "+" || bt.Text == "-" || bt.Text == "*" || bt.Text == "/")
            {
                opr = bt.Text; // Lưu phép toán
                workingMemory = decimal.Parse(txtDisplay.Text); // Lưu số thứ nhất vào bộ nhớ tạm
                txtDisplay.Clear(); // Xóa màn hình để nhập số thứ hai
            }
            // 3. Xử lý dấu Bằng = (Slide 87)
            else if (bt.Text == "=")
            {
                decimal secondValue = decimal.Parse(txtDisplay.Text); // Lấy số thứ hai
                switch (opr)
                {
                    case "+":
                        txtDisplay.Text = (workingMemory + secondValue).ToString();
                        break;
                    case "-":
                        txtDisplay.Text = (workingMemory - secondValue).ToString();
                        break;
                    case "*":
                        txtDisplay.Text = (workingMemory * secondValue).ToString();
                        break;
                    case "/":
                        // Kiểm tra chia cho 0
                        if (secondValue != 0)
                        {
                            txtDisplay.Text = (workingMemory / secondValue).ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không thể chia cho 0");
                        }
                        break;
                }
            }
            // 4. Các phép toán một ngôi: ±, √, %, 1/x (Slide 88)
            else if (bt.Text == "±") // Đổi dấu
            {
                decimal val = decimal.Parse(txtDisplay.Text);
                txtDisplay.Text = (-val).ToString();
            }
            else if (bt.Text == "√") // Căn bậc 2
            {
                double val = double.Parse(txtDisplay.Text);
                if (val >= 0)
                {
                    txtDisplay.Text = Math.Sqrt(val).ToString();
                }
            }
            else if (bt.Text == "%") // Phần trăm
            {
                decimal val = decimal.Parse(txtDisplay.Text);
                txtDisplay.Text = (val / 100).ToString();
            }
            else if (bt.Text == "1/x") // Nghịch đảo
            {
                decimal val = decimal.Parse(txtDisplay.Text);
                if (val != 0)
                {
                    txtDisplay.Text = (1 / val).ToString();
                }
            }
            // 5. Các chức năng xóa: ←, C, CE (Slide 89)
            else if (bt.Text == "←") // Backspace
            {
                if (txtDisplay.Text.Length > 0)
                {
                    txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
                }
                // Nếu xóa hết thì trả về số 0
                if (txtDisplay.Text == "")
                {
                    txtDisplay.Text = "0";
                }
            }
            else if (bt.Text == "C") // Clear All (Xóa hết bộ nhớ tạm và màn hình)
            {
                workingMemory = 0;
                opr = "";
                txtDisplay.Text = "0";
            }
            else if (bt.Text == "CE") // Clear Entry (Chỉ xóa số đang nhập trên màn hình)
            {
                txtDisplay.Text = "0";
            }
            // 6. Các chức năng bộ nhớ: MC, MR, MS, M+, M- (Slide 89, 90)
            else if (bt.Text == "MC") // Memory Clear
            {
                memory = 0;
            }
            else if (bt.Text == "MR") // Memory Recall
            {
                txtDisplay.Text = memory.ToString();
            }
            else if (bt.Text == "MS") // Memory Store
            {
                memory = decimal.Parse(txtDisplay.Text);
                txtDisplay.Text = "0"; // Sau khi lưu thường sẽ reset màn hình để nhập số mới
            }
            else if (bt.Text == "M+") // Memory Add
            {
                memory += decimal.Parse(txtDisplay.Text);
            }
            else if (bt.Text == "M-") // Memory Subtract
            {
                memory -= decimal.Parse(txtDisplay.Text);
            }
        }
    }
}