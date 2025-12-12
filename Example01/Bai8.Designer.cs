namespace Example01
{
    partial class Bai8
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbSoX = new Label();
            tbSoY = new Label();
            tbKetQua = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // tbSoX
            // 
            tbSoX.AutoSize = true;
            tbSoX.Location = new Point(189, 72);
            tbSoX.Name = "tbSoX";
            tbSoX.Size = new Size(46, 25);
            tbSoX.TabIndex = 0;
            tbSoX.Text = "Số x";
            // 
            // tbSoY
            // 
            tbSoY.AutoSize = true;
            tbSoY.Location = new Point(189, 138);
            tbSoY.Name = "tbSoY";
            tbSoY.Size = new Size(47, 25);
            tbSoY.TabIndex = 1;
            tbSoY.Text = "Số y";
            // 
            // tbKetQua
            // 
            tbKetQua.AutoSize = true;
            tbKetQua.Location = new Point(189, 198);
            tbKetQua.Name = "tbKetQua";
            tbKetQua.Size = new Size(72, 25);
            tbKetQua.TabIndex = 2;
            tbKetQua.Text = "Kết quả";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(306, 66);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(297, 31);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(306, 132);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(297, 31);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(306, 195);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(297, 31);
            textBox3.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(189, 264);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 6;
            button1.Text = "Cộng";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(340, 264);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 7;
            button2.Text = "Nhân";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(491, 264);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 8;
            button3.Text = "Thoát";
            button3.UseVisualStyleBackColor = true;
            // 
            // Bai8
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(tbKetQua);
            Controls.Add(tbSoY);
            Controls.Add(tbSoX);
            Name = "Bai8";
            Text = "Bai8";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tbSoX;
        private Label tbSoY;
        private Label tbKetQua;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}