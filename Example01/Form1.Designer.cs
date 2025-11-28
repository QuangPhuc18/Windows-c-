namespace Example01
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //SuspendLayout();
            //// 
            //// Form1
            //// 
            //AutoScaleDimensions = new SizeF(10F, 25F);
            //AutoScaleMode = AutoScaleMode.Font;
            //ClientSize = new Size(780, 450);
            //Name = "Form1";
            //Text = "Form1";
            //Load += Form1_Load;
            //ResizeEnd += Form1_ResizeEnd;
            //ResumeLayout(false);
            this.SuspendLayout();
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.ResumeLayout(false);   
        }

        #endregion
    }
}
