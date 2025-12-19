namespace Example01
{
    partial class Bai17
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
            this.lbSong = new System.Windows.Forms.ListBox();
            this.lbFavorite = new System.Windows.Forms.ListBox();
            this.btSelect = new System.Windows.Forms.Button();
            this.btDeselect = new System.Windows.Forms.Button();
            this.btSelectAll = new System.Windows.Forms.Button();
            this.btDeselectAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // 
            this.lbSong.FormattingEnabled = true;
            this.lbSong.ItemHeight = 16;
            this.lbSong.Items.AddRange(new object[] {
            "Nơi này có anh",
            "Lạc trôi",
            "Một triệu like",
            "Chờ anh nhé",
            "Tháng tư là lời nói dối của em",
            "Mơ hồ",
                });
            this.lbSong.Location = new System.Drawing.Point(30, 50);
            this.lbSong.Name = "lbSong";
            this.lbSong.Size = new System.Drawing.Size(250, 260);
            this.lbSong.TabIndex = 0;
            this.lbSong.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbSong_MouseDoubleClick);
            // 
            // 
            this.lbFavorite.FormattingEnabled = true;
            this.lbFavorite.ItemHeight = 16;
            this.lbFavorite.Location = new System.Drawing.Point(370, 50);
            this.lbFavorite.Name = "lbFavorite";
            this.lbFavorite.Size = new System.Drawing.Size(250, 260);
            this.lbFavorite.TabIndex = 1;
            this.lbFavorite.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbFavorite_MouseDoubleClick);
            // 
            // btSelect (>)
            // 
            this.btSelect.Location = new System.Drawing.Point(300, 70);
            this.btSelect.Name = "btSelect";
            this.btSelect.Size = new System.Drawing.Size(50, 30);
            this.btSelect.TabIndex = 2;
            this.btSelect.Text = ">";
            this.btSelect.UseVisualStyleBackColor = true;
            this.btSelect.Click += new System.EventHandler(this.btSelect_Click);
            // 
            // btDeselect (<)
            // 
            this.btDeselect.Location = new System.Drawing.Point(300, 120);
            this.btDeselect.Name = "btDeselect";
            this.btDeselect.Size = new System.Drawing.Size(50, 30);
            this.btDeselect.TabIndex = 3;
            this.btDeselect.Text = "<";
            this.btDeselect.UseVisualStyleBackColor = true;
            this.btDeselect.Click += new System.EventHandler(this.btDeselect_Click);
            // 
            // btSelectAll (>>)
            // 
            this.btSelectAll.Location = new System.Drawing.Point(300, 170);
            this.btSelectAll.Name = "btSelectAll";
            this.btSelectAll.Size = new System.Drawing.Size(50, 30);
            this.btSelectAll.TabIndex = 4;
            this.btSelectAll.Text = ">>";
            this.btSelectAll.UseVisualStyleBackColor = true;
            this.btSelectAll.Click += new System.EventHandler(this.btSelectAll_Click);
            // 
            // btDeselectAll (<<)
            // 
            this.btDeselectAll.Location = new System.Drawing.Point(300, 220);
            this.btDeselectAll.Name = "btDeselectAll";
            this.btDeselectAll.Size = new System.Drawing.Size(50, 30);
            this.btDeselectAll.TabIndex = 5;
            this.btDeselectAll.Text = "<<";
            this.btDeselectAll.UseVisualStyleBackColor = true;
            this.btDeselectAll.Click += new System.EventHandler(this.btDeselectAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Danh sách bài hát";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Danh sách bài hát ưa thích";
            // 
            // Bai17
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btDeselectAll);
            this.Controls.Add(this.btSelectAll);
            this.Controls.Add(this.btDeselect);
            this.Controls.Add(this.btSelect);
            this.Controls.Add(this.lbFavorite);
            this.Controls.Add(this.lbSong);
            this.Name = "Bai17";
            this.Text = "Music";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox lbSong;
        private System.Windows.Forms.ListBox lbFavorite;
        private System.Windows.Forms.Button btSelect;
        private System.Windows.Forms.Button btDeselect;
        private System.Windows.Forms.Button btSelectAll;
        private System.Windows.Forms.Button btDeselectAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}