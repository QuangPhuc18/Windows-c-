namespace Example01
{
    partial class Bai8
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblSoX = new Label();
            lblSoY = new Label();
            lblKetQua = new Label();
            tbSoX = new TextBox();
            tbSoY = new TextBox();
            tbKetQua = new TextBox();
            btnCong = new Button();
            btnNhan = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // lblSoX
            // 
            lblSoX.AutoSize = true;
            lblSoX.Location = new Point(160, 70);
            lblSoX.Name = "lblSoX";
            lblSoX.Size = new Size(46, 25);
            lblSoX.Text = "Số X";
            // 
            // lblSoY
            // 
            lblSoY.AutoSize = true;
            lblSoY.Location = new Point(160, 130);
            lblSoY.Name = "lblSoY";
            lblSoY.Size = new Size(47, 25);
            lblSoY.Text = "Số Y";
            // 
            // lblKetQua
            // 
            lblKetQua.AutoSize = true;
            lblKetQua.Location = new Point(160, 190);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(72, 25);
            lblKetQua.Text = "Kết quả";
            // 
            // tbSoX
            // 
            tbSoX.Location = new Point(260, 67);
            tbSoX.Name = "tbSoX";
            tbSoX.Size = new Size(250, 31);
            // 
            // tbSoY
            // 
            tbSoY.Location = new Point(260, 127);
            tbSoY.Name = "tbSoY";
            tbSoY.Size = new Size(250, 31);
            // 
            // tbKetQua
            // 
            tbKetQua.Location = new Point(260, 187);
            tbKetQua.Name = "tbKetQua";
            tbKetQua.ReadOnly = true;
            tbKetQua.Size = new Size(250, 31);
            // 
            // btnCong
            // 
            btnCong.Location = new Point(160, 260);
            btnCong.Name = "btnCong";
            btnCong.Size = new Size(100, 35);
            btnCong.Text = "Cộng";
            btnCong.UseVisualStyleBackColor = true;
            btnCong.Click += btnCong_Click;
            // 
            // btnNhan
            // 
            btnNhan.Location = new Point(285, 260);
            btnNhan.Name = "btnNhan";
            btnNhan.Size = new Size(100, 35);
            btnNhan.Text = "Nhân";
            btnNhan.UseVisualStyleBackColor = true;
            btnNhan.Click += btnNhan_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(410, 260);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(100, 35);
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // Bai8
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 380);
            Controls.Add(btnThoat);
            Controls.Add(btnNhan);
            Controls.Add(btnCong);
            Controls.Add(tbKetQua);
            Controls.Add(tbSoY);
            Controls.Add(tbSoX);
            Controls.Add(lblKetQua);
            Controls.Add(lblSoY);
            Controls.Add(lblSoX);
            Name = "Bai8";
            Text = "Bài 8 - Cộng & Nhân";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSoX;
        private Label lblSoY;
        private Label lblKetQua;
        private TextBox tbSoX;
        private TextBox tbSoY;
        private TextBox tbKetQua;
        private Button btnCong;
        private Button btnNhan;
        private Button btnThoat;
    }
}
