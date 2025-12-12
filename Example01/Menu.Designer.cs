namespace Example01
{
    partial class Menu
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
            btnExample01 = new Button();
            btn_example01 = new Button();
            btn_05 = new Button();
            btn_06 = new Button();
            btn_07 = new Button();
            btn_08 = new Button();
            SuspendLayout();
            // 
            // btnExample01
            // 
            btnExample01.BackColor = SystemColors.GradientActiveCaption;
            btnExample01.Location = new Point(116, 73);
            btnExample01.Name = "btnExample01";
            btnExample01.Size = new Size(131, 62);
            btnExample01.TabIndex = 0;
            btnExample01.Text = "Example1,2";
            btnExample01.UseVisualStyleBackColor = false;
            btnExample01.Click += button01_Click;
            // 
            // btn_example01
            // 
            btn_example01.BackColor = SystemColors.GradientActiveCaption;
            btn_example01.Location = new Point(300, 73);
            btn_example01.Name = "btn_example01";
            btn_example01.Size = new Size(140, 62);
            btn_example01.TabIndex = 1;
            btn_example01.Text = "Example03";
            btn_example01.UseVisualStyleBackColor = false;
            btn_example01.Click += btn_example01_Click;
            // 
            // btn_05
            // 
            btn_05.BackColor = SystemColors.GradientActiveCaption;
            btn_05.Location = new Point(506, 73);
            btn_05.Name = "btn_05";
            btn_05.Size = new Size(140, 62);
            btn_05.TabIndex = 2;
            btn_05.Text = "Example05";
            btn_05.UseVisualStyleBackColor = false;
            btn_05.Click += btn_05_Click;
            // 
            // btn_06
            // 
            btn_06.BackColor = SystemColors.GradientActiveCaption;
            btn_06.Location = new Point(116, 197);
            btn_06.Name = "btn_06";
            btn_06.Size = new Size(140, 62);
            btn_06.TabIndex = 3;
            btn_06.Text = "Example06";
            btn_06.UseVisualStyleBackColor = false;
            btn_06.Click += btn_06_Click;
            // 
            // btn_07
            // 
            btn_07.BackColor = SystemColors.GradientActiveCaption;
            btn_07.Location = new Point(300, 197);
            btn_07.Name = "btn_07";
            btn_07.Size = new Size(140, 62);
            btn_07.TabIndex = 4;
            btn_07.Text = "Example07";
            btn_07.UseVisualStyleBackColor = false;
            btn_07.Click += btn_07_Click;
            // 
            // btn_08
            // 
            btn_08.BackColor = SystemColors.GradientActiveCaption;
            btn_08.Location = new Point(506, 197);
            btn_08.Name = "btn_08";
            btn_08.Size = new Size(140, 62);
            btn_08.TabIndex = 5;
            btn_08.Text = "Exmple08";
            btn_08.UseVisualStyleBackColor = false;
            btn_08.Click += btn_08_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_08);
            Controls.Add(btn_07);
            Controls.Add(btn_06);
            Controls.Add(btn_05);
            Controls.Add(btn_example01);
            Controls.Add(btnExample01);
            Name = "Menu";
            Text = "Example04";
            Load += Menu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnExample01;
        private Button btn_example01;
        private Button btn_05;
        private Button btn_06;
        private Button btn_07;
        private Button btn_08;
    }
}