using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV
{
    public partial class Form2 : Form
    {
        public Form2(string firstname, string lastname, string fathername, string CNIC, string Regno, string contactno, Bitmap? CaptureImage)
        {
            InitializeComponent();
            textBox1.Text = firstname;
            textBox5.Text = lastname;
            textBox8.Text = fathername;
            textBox7.Text = CNIC;
            textBox2.Text = Regno;
            textBox6.Text = contactno;

            if (CaptureImage != null)
            {
                pictureBox1.Image = new Bitmap(CaptureImage);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
