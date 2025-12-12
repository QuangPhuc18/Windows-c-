using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Example01
{
    public partial class Bai3 : Form
    {
        string path = "D:\form.xml";
        InfoWindows iw = new InfoWindows();

        public Bai3()
        {
            InitializeComponent();
        }

        public void Write(InfoWindows iw)
        {
            XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
            StreamWriter file = new StreamWriter(path);          
             writer.Serialize(file, iw);
            file.Close();
        }
        public InfoWindows Read()
        {
            XmlSerializer reader = new XmlSerializer(typeof(InfoWindows));
            StreamReader file = new StreamReader(path);
            InfoWindows iw = (InfoWindows)reader.Deserialize(file);
            file.Close();
            return iw;

        }
        void Form1_Load(object sender, EventArgs e)
        {
            iw = Read();
            this.Width = iw.Width;
            this.Height = iw.Height;
            this.Location=iw.Location;
        }
        public void Form1_FormClosing(object sender,EventArgs e)
        {
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            iw.Location = this.Location;
            Write(iw);
        }

    }
}
