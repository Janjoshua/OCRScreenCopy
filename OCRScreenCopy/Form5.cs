using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace OCRScreenCopy
{
    public partial class Form5 : Form
    {
        Image image;
        Bitmap img;
        Form2 FormText;
        public Form5(Image image)
        {
            InitializeComponent();
            this.image = image;
            pictureBox1.Image = image;
        }
        private Bitmap capturearea(Control control)
        {
            Size size = control.ClientSize;
            Bitmap tmpBmp = new Bitmap(size.Width, size.Height);
            Graphics g;
            g = Graphics.FromImage(tmpBmp);
            g.CopyFromScreen(control.PointToScreen(new Point(0, 0)), new Point(0, 0), new Size(size.Width, size.Height));
            return tmpBmp;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormText = new Form2();
            img = capturearea(pictureBox1);
            TesseractEngine engine = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
            Page page = engine.Process(img, PageSegMode.Auto);
            FormText.richTextBox1.Text = page.GetText();
            FormText.Show();
            this.Hide();
        }
    }
}
