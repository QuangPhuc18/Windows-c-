namespace Example01
{
    partial class Bai7
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
            tbYear = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // tbYear
            // 
            tbYear.AutoSize = true;
            tbYear.Location = new Point(173, 67);
            tbYear.Name = "tbYear";
            tbYear.Size = new Size(44, 25);
            tbYear.TabIndex = 0;
            tbYear.Text = "Year";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(173, 127);
            label2.Name = "label2";
            label2.Size = new Size(132, 25);
            label2.TabIndex = 1;
            label2.Text = "Phone Number";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(331, 67);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(204, 31);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(331, 127);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(204, 31);
            textBox2.TabIndex = 3;
            // 
            // Bai7
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(tbYear);
            Name = "Bai7";
            Text = "form7";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tbYear;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}