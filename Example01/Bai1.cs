using System.Xml.Serialization;

namespace Example01
{
    public partial class Bai1 : Form
    {
        string path = @"D:\form.xml";

        public Bai1()
        {
            InitializeComponent();
        }

        public void Write(InfoWindows iw)
        {
            XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
            using (StreamWriter file = new StreamWriter(path))
            {
                writer.Serialize(file, iw);
            }
        }

      
        public InfoWindows Read()
        {
            XmlSerializer reader = new XmlSerializer(typeof(InfoWindows));
            using (StreamReader file = new StreamReader(path))
            {
                return (InfoWindows)reader.Deserialize(file);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Width;
            iw.Height = this.Height;

            Write(iw);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            InfoWindows iw = Read();

            this.Width = iw.Width;
            this.Height = iw.Height;
        }
    }
}
