namespace Example01
{
    partial class Bai5
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
            label1 = new Label();
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            checkBox1 = new CheckBox();
            radioButton1 = new RadioButton();
            comboBox1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            listBox1 = new ListBox();
            btnOk = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 45);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(149, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 31);
            textBox1.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(444, 39);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(164, 31);
            numericUpDown1.TabIndex = 2;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(64, 102);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(124, 29);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "CheckBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(244, 102);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(146, 29);
            radioButton1.TabIndex = 4;
            radioButton1.TabStop = true;
            radioButton1.Text = "RadioButton1";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(64, 164);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(335, 33);
            comboBox1.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(64, 227);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(335, 31);
            dateTimePicker1.TabIndex = 6;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(64, 300);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(263, 129);
            listBox1.TabIndex = 7;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(444, 431);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(112, 34);
            btnOk.TabIndex = 8;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // Bai5
            // 
            ClientSize = new Size(632, 477);
            Controls.Add(btnOk);
            Controls.Add(listBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox1);
            Controls.Add(radioButton1);
            Controls.Add(checkBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            KeyPreview = true;
            Name = "Bai5";
            ShowInTaskbar = false;
            Text = "Form3";
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label label1;
        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private CheckBox checkBox1;
        private RadioButton radioButton1;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private ListBox listBox1;
        private Button btnOk;
    }
}
