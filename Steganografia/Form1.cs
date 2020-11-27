using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganografia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            otwarcieChildForm(new zakodowanie());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            otwarcieChildForm(new dekodowanie());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            otwarcieChildForm(new zakodowanie());
        }
        private Form aktywnyForm = null;
        private void otwarcieChildForm(Form childForm)
        {
            if (aktywnyForm != null)
            {
                aktywnyForm.Close();
            }
            aktywnyForm = childForm;
            childForm.TopLevel = false;
            aktywnyForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            aktywnyChild.Controls.Add(childForm);
            aktywnyChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void aktywnyChild_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void aktywnyChild_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            aktywnyForm.Close();
            aktywnyForm = null;

        }
    }
}
