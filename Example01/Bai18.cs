using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example01
{
    public partial class Bai18 : Form
    {
        public Bai18()
        {
            InitializeComponent();
        }

        public ArrayList GetData()
        {
            ArrayList lst = new ArrayList();

            Song s = new Song();
            s.Id = 53418;
            s.Name = "Noi này có anh";
            s.Author = "Sơn Tùng MTP";
            lst.Add(s);

            s = new Song();
            s.Id = 52616;
            s.Name = "Chờ anh nhé";
            s.Author = "Hoàng Dũng";
            lst.Add(s);

            s = new Song();
            s.Id = 51172;
            s.Name = "Cơn mưa ngang qua";
            s.Author = "Sơn Tùng MTP";
            lst.Add(s);

            return lst;
        }

        private void Bai18_Load(object sender, EventArgs e)
        {
            ArrayList lst = GetData();
            lbSong.DataSource = lst;
            lbSong.DisplayMember = "Name";
        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            Song song = (Song)lbSong.SelectedItem;
            string id = song.Id.ToString();
            string name = song.Name;
            string author = song.Author;
            lbFavorite.Items.Add(id + " - " + name + " - " + author);
        }
    }
}