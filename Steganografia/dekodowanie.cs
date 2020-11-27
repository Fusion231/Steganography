using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganografia
{
    public partial class dekodowanie : Form
    {
        bool muzykaPlay = false;
        SoundPlayer s;
        byte[] bytes;
        Wave wave;
        Obraz obraz;
        StringBuilder rozszerzenie = new StringBuilder();
        public dekodowanie()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            label7.Hide();
            comboBox4.Hide();
        }
        public static byte[] GetBytes(string bitString)
        {
            return Enumerable.Range(0, bitString.Length / 8).
                Select(pos => Convert.ToByte(
                    bitString.Substring(pos * 8, 8),
                    2)
                ).ToArray();
        }
        private void dekodowanie_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int bityRed = Convert.ToInt32(comboBox1.SelectedItem.ToString());
            int bityGreen = Convert.ToInt32(comboBox2.SelectedItem.ToString());
            int bityBlue = Convert.ToInt32(comboBox3.SelectedItem.ToString());
            Bitmap img = obraz.dekodowanieObrazu(bityRed, bityGreen, bityBlue);
                SaveFileDialog savefile = new SaveFileDialog();
                saveFileDialog1.Filter = "Image Files (*.png) | *.png";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    img.Save(saveFileDialog1.FileName);
                    MessageBox.Show("Zapis został wykonany pomyślnie");
                }
        }
        private void wybierzukryty_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rozszerzenie.Clear();
                sciezka.Text = openFileDialog1.FileName.ToString();
                rozszerzenie.Append(Path.GetExtension(sciezka.Text));
                if (rozszerzenie.ToString() == ".wav")
                {
                    bytes = File.ReadAllBytes(sciezka.Text);
                    wave = new Wave(bytes);
                    podglad.ImageLocation = "F:/Szkola/2020-2021/Kryptografia/Cw2/img/play.png";
                    s = new SoundPlayer(openFileDialog1.FileName);
                    label7.Show();
                    comboBox4.Show();
                    label4.Hide();
                    label5.Hide();
                    label6.Hide();
                    comboBox1.Hide();
                    comboBox2.Hide();
                    comboBox3.Hide();
                    comboBox4.Items.Clear();
                    for (int q = 1; q <= wave.probkowanie; q++)
                    {
                        comboBox4.Items.Add(q);
                    }
                    comboBox4.SelectedIndex = 3;
                }
                else if (rozszerzenie.ToString() == ".png" || rozszerzenie.ToString() == ".jpg" || rozszerzenie.ToString() == ".jpeg")
                {
                    obraz = new Obraz(new Bitmap(sciezka.Text));
                    podglad.ImageLocation = sciezka.Text;
                    label4.Show();
                    label5.Show();
                    label6.Show();
                    comboBox1.Show();
                    comboBox2.Show();
                    comboBox3.Show();
                    label7.Hide();
                    comboBox4.Hide();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            wyjscie.Text = obraz.dekodowanieTekst();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (wave != null)
            {
                int bity = Convert.ToInt32(comboBox4.SelectedItem.ToString());
                wave.dekodowanie(bity);
                saveFileDialog1.FileName = "test." + wave.rozszerzenieOdkodowanyplik;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.Filter = string.Format(" (*.{0})|*.{0}", wave.rozszerzenieOdkodowanyplik);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    byte[] bytes = GetBytes(wave.bityOdkodowanyplik.ToString());
                    File.WriteAllBytes(saveFileDialog1.FileName, bytes);
                    MessageBox.Show("Zapis został wykonany pomyślnie");
                }
            }
            else
            {
                int bityRed = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                int bityGreen = Convert.ToInt32(comboBox2.SelectedItem.ToString());
                int bityBlue = Convert.ToInt32(comboBox3.SelectedItem.ToString());
                obraz.dekodowanie(bityRed, bityGreen, bityBlue);
                saveFileDialog1.FileName = "test." + obraz.rozszerzenie;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.Filter = string.Format(" (*.{0})|*.{0}", obraz.rozszerzenie);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    byte[] bytes = GetBytes(obraz.bity.ToString());
                    File.WriteAllBytes(saveFileDialog1.FileName, bytes);
                    MessageBox.Show("Zapis został wykonany pomyślnie");
                }
            }
        }

        private void podglad_Click(object sender, EventArgs e)
        {
            if (rozszerzenie.ToString() == ".wav")
            {
                if (muzykaPlay)
                {
                    s.Stop();
                    muzykaPlay = false;
                }
                else
                {
                    s.Play();
                    muzykaPlay = true;
                }
            }
        }
    }
}
