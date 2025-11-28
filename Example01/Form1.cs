using System.Xml.Serialization;

namespace Example01
{
    public partial class Form1 : Form
    {
        string path = @"D:\form.xml";
        public Form1()
        {
            InitializeComponent();  
        }

        public void Write(InfoWindows iw) {
            XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
            StreamWriter file = new StreamWriter(path);
            writer.Serialize(file, iw);
            file.Close();
        }
        public InfoWindows Read() {
            XmlSerializer reader = new XmlSerializer(typeof(InfoWindows));
            StreamReader file = new StreamReader(path);
            InfoWindows iw = (InfoWindows)reader.Deserialize(file);
            file.Close ();
            return iw;



        }
        public void Form1_Load(object sender, System.EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            Write(iw);
        }

         public void Form1_ResizeEnd(object sender, System.EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw = Read();
            this.Width = this.Size.Width;
            this.Height = this.Size.Height;
        }
        //void Form1(object sender, EventArgs e) { 

        //}

    }
}
