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
            SuspendLayout();
            // 
            // btnExample01
            // 
            btnExample01.BackColor = SystemColors.GradientActiveCaption;
            btnExample01.Location = new Point(116, 73);
            btnExample01.Name = "btnExample01";
            btnExample01.Size = new Size(131, 62);
            btnExample01.TabIndex = 0;
            btnExample01.Text = "Example01";
            btnExample01.UseVisualStyleBackColor = false;
            btnExample01.Click += button01_Click;
            // 
            // btn_example01
            // 
            btn_example01.BackColor = SystemColors.GradientActiveCaption;
            btn_example01.Location = new Point(318, 73);
            btn_example01.Name = "btn_example01";
            btn_example01.Size = new Size(140, 62);
            btn_example01.TabIndex = 1;
            btn_example01.Text = "Example02";
            btn_example01.UseVisualStyleBackColor = false;
            btn_example01.Click += btn_example01_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_example01);
            Controls.Add(btnExample01);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnExample01;
        private Button btn_example01;
    }
}