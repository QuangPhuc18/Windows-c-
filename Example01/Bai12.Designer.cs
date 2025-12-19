namespace Example01
{
    partial class Bai12
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cb_Faculty = new System.Windows.Forms.ComboBox();
            this.btOK = new System.Windows.Forms.Button();
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_Faculty
            // 
            this.cb_Faculty.FormattingEnabled = true;
            this.cb_Faculty.Location = new System.Drawing.Point(30, 40);
            this.cb_Faculty.Name = "cb_Faculty";
            this.cb_Faculty.Size = new System.Drawing.Size(300, 24);
            this.cb_Faculty.TabIndex = 0;
            // QUAN TRỌNG: Đã sửa dòng này để gọi hàm SelectedValueChanged (theo Slide 101)
            this.cb_Faculty.SelectedValueChanged += new System.EventHandler(this.cb_Faculty_SelectedValueChanged);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(350, 38);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 28);
            this.btOK.TabIndex = 1;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // tbDisplay
            // 
            this.tbDisplay.Location = new System.Drawing.Point(30, 90);
            this.tbDisplay.Multiline = true;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.Size = new System.Drawing.Size(395, 80);
            this.tbDisplay.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chọn khoa:";
            // 
            // Bai12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 200);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDisplay);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.cb_Faculty);
            this.Name = "Bai12";
            this.Text = "ComboBox Dynamic Binding";
            // Sự kiện Load form
            this.Load += new System.EventHandler(this.Bai12_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Faculty;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.TextBox tbDisplay;
        private System.Windows.Forms.Label label1;
    }
}