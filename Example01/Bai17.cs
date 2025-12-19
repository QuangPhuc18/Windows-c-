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
    public partial class Bai17 : Form
    {
        public Bai17()
        {
            InitializeComponent();
        }

        // 1. Nút chọn một bài (>) - Slide 118
        private void btSelect_Click(object sender, EventArgs e)
        {
            if (lbSong.SelectedItem != null)
            {
                string song = lbSong.SelectedItem.ToString();
                lbFavorite.Items.Add(song);
                lbSong.Items.RemoveAt(lbSong.SelectedIndex);
            }
        }

        // 2. Nút bỏ chọn một bài (<) - Tương tự logic trên nhưng ngược lại
        private void btDeselect_Click(object sender, EventArgs e)
        {
            if (lbFavorite.SelectedItem != null)
            {
                string song = lbFavorite.SelectedItem.ToString();
                lbSong.Items.Add(song);
                lbFavorite.Items.RemoveAt(lbFavorite.SelectedIndex);
            }
        }

        // 3. Nút chọn tất cả (>>) - Logic vòng lặp ngược theo gợi ý Slide 119
        private void btSelectAll_Click(object sender, EventArgs e)
        {
            // Duyệt từ cuối danh sách lên đầu để khi xóa không bị sai chỉ số (Index)
            for (int i = lbSong.Items.Count - 1; i >= 0; i--)
            {
                string song = lbSong.Items[i].ToString();
                lbFavorite.Items.Add(song);
                lbSong.Items.RemoveAt(i);
            }
        }

        // 4. Nút bỏ chọn tất cả (<<)
        private void btDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = lbFavorite.Items.Count - 1; i >= 0; i--)
            {
                string song = lbFavorite.Items[i].ToString();
                lbSong.Items.Add(song);
                lbFavorite.Items.RemoveAt(i);
            }
        }

        // 5. Sự kiện Click đúp chuột vào bài hát (Slide 119)
        private void lbSong_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Kiểm tra xem vị trí click chuột có trúng vào item nào không
            int index = this.lbSong.IndexFromPoint(e.Location);

            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                string song = lbSong.Items[index].ToString();
                lbFavorite.Items.Add(song);
                lbSong.Items.RemoveAt(index);
            }
        }

        // 6. Sự kiện Click đúp chuột vào bài ưa thích (ngược lại)
        private void lbFavorite_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lbFavorite.IndexFromPoint(e.Location);

            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                string song = lbFavorite.Items[index].ToString();
                lbSong.Items.Add(song);
                lbFavorite.Items.RemoveAt(index);
            }
        }
    }
}