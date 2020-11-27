using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganografia
{
    public partial class zakodowanie : Form
    {
        int maxPojemnosc = 0, pojemnoscNosnika = 0;
        daneUkrytyPlik daneukryty;
        Wave wave;
        Obraz obraz;
        byte[] bytes;
        StringBuilder bity, bityRozszerzenie;
        Bitmap img;
        string rozszerzenie, rozszerzenieWejscie;
        bool muzykaPlay = false;
        SoundPlayer s;
        float pojemnoscNosnikaMaximum;
        int bityRed, bityGreen, bityBlue;
        protected List<string> extensionsList = new List<string> {
                "txt","blend","m",
                "jpg", "png", "gif", "bmp", "tiff", "psd",
                "mp4", "mkv", "avi", "mov", "mpg", "vob",
                "mp3", "aac", "wav", "flac", "ogg", "mka", "wma",
                "pdf", "doc", "xls", "ppt", "docx", "odt",
                "zip", "rar", "7z", "tar", "iso",
                "mdb", "accde", "frm", "sqlite",
                "exe", "dll", "so", "class"
            };
        public static byte[] GetBytes(string bitString)
        {
            return Enumerable.Range(0, bitString.Length / 8).
                Select(pos => Convert.ToByte(
                    bitString.Substring(pos * 8, 8),
                    2)
                ).ToArray();
        }
       
        public string sprawdzenie(Bitmap img, int bityRed, int bityGreen, int bityBlue)
        {
            int przesuniecier = (8 - bityRed);
            int maskar = 0xFF >> przesuniecier;

            int przesuniecieg = (8 - bityGreen);
            int maskag = 0xFF >> przesuniecieg;

            int przesuniecieb = (8 - bityBlue);
            int maskab = 0xFF >> przesuniecieb;

            //Wartosci
            bool stop = false;
            StringBuilder vr;
            StringBuilder vg;
            StringBuilder vb;
            int iloscDlugosc = 0, iloscRozszerzenie = 0, Temp1 = 0, Temp2 = 0;
            String iloscPixeliDlugosc = "", iloscPixeliRozszerzenie = "", dlugosc = "", format = "", rozszerzenie = "";
            StringBuilder plik = new StringBuilder();
            byte[] dlugoscRozszerzenieTemp = null;
            for (int q = 0; q < img.Width; q++)
            {
                for (int w = 0; w < img.Height; w++)
                {
                    Color pixel = img.GetPixel(q, w);
                    vr = new StringBuilder(Convert.ToString((pixel.R & maskar), 2));
                    vg = new StringBuilder(Convert.ToString((pixel.G & maskag), 2));
                    vb = new StringBuilder(Convert.ToString((pixel.B & maskab), 2));
                    while (vr.Length % (bityRed) != 0)
                    {
                        vr.Insert(0, "0");
                    }
                    while (vg.Length % (bityGreen) != 0)
                    {
                        vg.Insert(0, "0");

                    }
                    while (vb.Length % (bityBlue) != 0)
                    {
                        vb.Insert(0, "0");
                    }
                    if (q == 0 && w <= 1)
                    {
                        iloscPixeliDlugosc += vr.ToString() + vg.ToString() + vb.ToString();
                        continue;
                    }
                    if (q == 0 && (w == 2 || w == 3))
                    {
                        iloscPixeliRozszerzenie += vr.ToString() + vg.ToString() + vb.ToString();
                        continue;
                    }
                    if (w == 4 && iloscDlugosc == 0 && q == 0)
                    {
                        iloscDlugosc = Convert.ToInt32(iloscPixeliDlugosc, 2);
                        iloscRozszerzenie = Convert.ToInt32(iloscPixeliRozszerzenie, 2);
                        Temp1 = Convert.ToInt32(iloscPixeliDlugosc, 2);
                        Temp2 = Convert.ToInt32(iloscPixeliRozszerzenie, 2);
                    }
                    if (iloscDlugosc >= img.Height)
                    {
                        return "Status pliku: Nie posiada element zakodowanego";
                    }
                    if (iloscDlugosc > 0)
                    {

                        dlugosc += vr.ToString() + vg.ToString() + vb.ToString();
                        iloscDlugosc--;
                        continue;
                    }
                    if (iloscRozszerzenie > 0)
                    {
                        format += vr.ToString() + vg.ToString() + vb.ToString();
                        iloscRozszerzenie--;
                        continue;
                    }
                    if (iloscRozszerzenie == 0 && w == (4 + Temp1 + Temp2) && q == 0)
                    {
                        dlugoscRozszerzenieTemp = GetBytes(format);
                        foreach (byte b in dlugoscRozszerzenieTemp)
                        {
                            if (dlugoscRozszerzenieTemp[dlugoscRozszerzenieTemp.Length-1] == 0 && b == 0)
                            {
                                break;
                            }
                            String letter = Encoding.ASCII.GetString(new byte[] { Convert.ToByte(b) });
                            rozszerzenie += letter;
                        }
                    }
                    if (!extensionsList.Contains(rozszerzenie))
                    {
                        return "Status pliku: Nie posiada element zakodowanego";
                    }
                    stop = true;
                    break;
                }
                if (stop)
                {
                    break;
                }
            }
            
            return "Status pliku: Posiada element zakodowany " + rozszerzenie;
        }
        public zakodowanie()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 3;
            comboBox2.SelectedIndex = 3;
            comboBox3.SelectedIndex = 3;
            label7.Hide();
            comboBox4.Hide();
            label1.Hide();
            nazwawav.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Image Files(*.png) | *.png; *.wav";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog1.FileName) == ".wav")
                {
                    img = null;
                    s = new SoundPlayer(openFileDialog1.FileName);
                    nazwawav.Show();
                    sciezka.Text = openFileDialog1.FileName.ToString();
                    podglad.Hide();
                    play.Show();
                    nazwawav.Show();
                    play.ImageLocation = "F:/Szkola/2020-2021/Kryptografia/Cw2/img/play.png";
                    label4.Hide();
                    label5.Hide();
                    label6.Hide();
                    comboBox1.Hide();
                    comboBox2.Hide();
                    comboBox3.Hide();
                    label7.Show();
                    comboBox4.Show();
                    nazwawav.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    rozszerzenieWejscie = Path.GetExtension(sciezka.Text);
                    bytes = File.ReadAllBytes(sciezka.Text);
                    wave = new Wave(bytes);
                    comboBox4.Items.Clear();
                    for (int q = 1;q<= wave.probkowanie; q++)
                    {
                        comboBox4.Items.Add(q);
                    }
                    comboBox4.SelectedIndex = 3;
                    status.Text = wave.sprawdzenie(Convert.ToInt32(comboBox4.SelectedItem.ToString()));
                    rozszerzenieWejscie = Path.GetExtension(sciezka.Text);
                    maxPojemnosc = (int)wave.sample * (Convert.ToInt32(comboBox4.SelectedItem.ToString()));
                    progressBar1.Maximum = Convert.ToInt32(maxPojemnosc);
                    progressBar1.Value = Convert.ToInt32(pojemnoscNosnika);
                    float pojemnoscProcenty = (float)Math.Round(((float)pojemnoscNosnika / (float)maxPojemnosc) * 100);
                    if (daneukryty == null || daneukryty.bity.Length == 0 || daneukryty.bity == null)
                    {
                        procenty.Text = "0 %";
                        rozmiar.Text = "0 kB";
                    }
                    else
                    {
                        procenty.Text = pojemnoscProcenty.ToString() + "%";
                        rozmiar.Text = Math.Round((Convert.ToDouble(maxPojemnosc) / 8) / 1024, 2) + " / " +
                        Math.Round((Convert.ToDouble(pojemnoscNosnika) / 8) / 1024, 2);
                    }
                }
                else
                {
                    podglad.Show();
                    play.Hide();
                    nazwawav.Hide();
                    label7.Hide();
                    comboBox4.Hide();
                    label4.Show();
                    label5.Show();
                    label6.Show();
                    comboBox1.Show();
                    comboBox2.Show();
                    comboBox3.Show();
                    sciezka.Text = openFileDialog1.FileName.ToString();
                    podglad.ImageLocation = sciezka.Text;
                    img = new Bitmap(sciezka.Text);
                    Color ostatniPixel = img.GetPixel(img.Width - 1, img.Height - 1);
                    int ostatniPixelWielkosc = ostatniPixel.B;
                    bityRed = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                    bityGreen = Convert.ToInt32(comboBox2.SelectedItem.ToString());
                    bityBlue = Convert.ToInt32(comboBox3.SelectedItem.ToString());
                    status.Text = sprawdzenie(img, bityRed, bityGreen, bityBlue);
                    rozszerzenieWejscie = Path.GetExtension(sciezka.Text);
                    if (rozszerzenie == ".png" || rozszerzenie == ".jpg" || rozszerzenie == ".jpeg")
                    {
                        rodzajwejscie.Text = "Rodzaj pliku: Zdjecie";
                        podglad.ImageLocation = textBox1.Text;

                    }
                    else if (rozszerzenie == ".txt")
                    {
                        rodzajwejscie.Text = "Rodzaj pliku: Tekstowy";
                    }
                    maxPojemnosc = img.Width * img.Height * (Convert.ToInt32(comboBox1.SelectedItem.ToString())
                        + Convert.ToInt32(comboBox2.SelectedItem.ToString()) + Convert.ToInt32(comboBox3.SelectedItem.ToString()));
                    progressBar1.Maximum = Convert.ToInt32(maxPojemnosc);
                    progressBar1.Value = Convert.ToInt32(pojemnoscNosnika);
                    float pojemnoscProcenty = (float)Math.Round(((float)pojemnoscNosnika / (float)maxPojemnosc) * 100);
                    if (daneukryty == null || daneukryty.bity.Length == 0 || daneukryty.bity == null)
                    {
                        procenty.Text = "0 %";
                        rozmiar.Text = "0 kB";
                    }
                    else
                    {
                        procenty.Text = pojemnoscProcenty.ToString() + "%";
                        rozmiar.Text = Math.Round((Convert.ToDouble(maxPojemnosc) / 8) / 1024, 2) + " / " +
                        Math.Round((Convert.ToDouble(pojemnoscNosnika) / 8) / 1024, 2);
                        label10.Text = Math.Round(Convert.ToDouble(((img.Width * img.Height * 24) / 8) / 1024), 2).ToString();
                    }
                }
            }
        }

        private void wykonaj_Click(object sender, EventArgs e)
        {
            if (rozszerzenie == ".png" && comboBox1.SelectedIndex <= -1 && comboBox2.SelectedIndex <= -1 && comboBox3.SelectedIndex <= -1)
            {
                MessageBox.Show("Prosze wprowadzic ilosc bitow");
                return;
            }
            bityRed = Convert.ToInt32(comboBox1.SelectedItem.ToString());
            bityGreen = Convert.ToInt32(comboBox2.SelectedItem.ToString());
            bityBlue = Convert.ToInt32(comboBox3.SelectedItem.ToString());
            if (rozszerzenie == ".png" && rozszerzenieWejscie != ".wav")
            {
                obraz = new Obraz(img, daneukryty.bity, daneukryty.bityRozszerzenie);
                img = obraz.dowolnyPlik(bityRed, bityGreen, bityBlue);
            }
            else if (rozszerzenie == ".txt" && rozszerzenieWejscie != ".wav")
            {
                obraz = new Obraz(img, bity, bityRozszerzenie);
                img = obraz.tekstwObrazie(daneukryty);

            } else if (rozszerzenieWejscie == ".wav") {
                int bitySciezka = Convert.ToInt32(comboBox4.SelectedItem.ToString());
                wave.kodowanie(bitySciezka, daneukryty.bityRozszerzenie, daneukryty.bity);
            } else
            {
                obraz = new Obraz(img, bity, bityRozszerzenie);
                img = obraz.dowolnyPlik(bityRed, bityGreen, bityBlue);
            }
            if (rozszerzenieWejscie == ".png" || rozszerzenieWejscie == ".jpg" || rozszerzenieWejscie == ".jpeg")
            {
                saveFileDialog1.Filter = "Image Files (*.png) | *.png";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = saveFileDialog1.FileName.ToString();
                    pozakodowaniu.Image = img;
                    img.Save(textBox1.Text, ImageFormat.Png);
                    MessageBox.Show("Zapis został wykonany pomyślnie");
                }
            }
            else if (rozszerzenieWejscie == ".wav")
            {
                saveFileDialog1.FileName = "test" + rozszerzenieWejscie;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.Filter = string.Format(" (*.{0})|*{0}", rozszerzenieWejscie);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    wave.Save();
                    File.WriteAllBytes(saveFileDialog1.FileName, wave.dane);
                    MessageBox.Show("Zapis został wykonany pomyślnie");
                }
            }
            label1.Show();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            error.Text = "";
            if (img != null)
            {
                maxPojemnosc = img.Width * img.Height * (Convert.ToInt32(comboBox1.SelectedItem.ToString())
                        + Convert.ToInt32(comboBox2.SelectedItem.ToString()) + Convert.ToInt32(comboBox3.SelectedItem.ToString()));
                pojemnoscNosnika = daneukryty.bity.Length;
                progressBar1.Maximum = Convert.ToInt32(maxPojemnosc);
                try
                {
                    progressBar1.Value = Convert.ToInt32(pojemnoscNosnika);
                }
                catch (Exception ex)
                {
                    error.Text = "Zwiększ bity !";
                }
                float pojemnoscProcenty = (float)Math.Round(((float)pojemnoscNosnika / (float)maxPojemnosc) * 100);
                if (daneukryty == null || daneukryty.bity.Length == 0 || daneukryty.bity == null)
                    {
                    procenty.Text = "0 %";
                    rozmiar.Text = "0 kB";
                }
                    else
                {
                    procenty.Text = pojemnoscProcenty.ToString() + "%";
                    rozmiar.Text = Math.Round((Convert.ToDouble(maxPojemnosc) / 8) / 1024, 2) + " / " +
                        Math.Round((Convert.ToDouble(pojemnoscNosnika) / 8) / 1024, 2);
                }

            }
            else if(wave != null && daneukryty != null)
            {
                maxPojemnosc = (int)wave.sample * (Convert.ToInt32(comboBox4.SelectedItem.ToString()));
                pojemnoscNosnika = daneukryty.bity.Length;
                progressBar1.Maximum = Convert.ToInt32(maxPojemnosc);
                try
                {
                    progressBar1.Value = Convert.ToInt32(pojemnoscNosnika);
                }
                catch (Exception ex)
                {
                    error.Text = "Zwiększ bity !";
                }
                float pojemnoscProcenty = (float)Math.Round(((float)pojemnoscNosnika / (float)maxPojemnosc) * 100);
                if (daneukryty == null || daneukryty.bity.Length == 0 || daneukryty.bity == null)
                {
                    procenty.Text = "0 %";
                    rozmiar.Text = "0 kB";
                }
                else
                {
                    procenty.Text = pojemnoscProcenty.ToString() + "%";
                    rozmiar.Text = Math.Round((Convert.ToDouble(maxPojemnosc) / 8) / 1024, 2) + " / " +
                    Math.Round((Convert.ToDouble(pojemnoscNosnika) / 8) / 1024, 2);
                    label10.Text = Math.Round(Convert.ToDouble(((img.Width * img.Height * 24) / 8) / 1024), 2).ToString();
                }
            }
            
        }

        private void zakodowanie_Load(object sender, EventArgs e)
        {

        }

        private void play_Click(object sender, EventArgs e)
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

        private void rozmiar_Click(object sender, EventArgs e)
        {

        }

        private void aktywnyChild_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dekodowanie_Click(object sender, EventArgs e)
        {
            dekodowanie dok = new dekodowanie();
            dok.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //otwarcieChildForm(new zakodowanie());
        }

        private void wybierzukryty_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
           
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName.ToString();
                bytes = File.ReadAllBytes(textBox1.Text);
                rozszerzenie = Path.GetExtension(textBox1.Text);
                if (Path.GetExtension(sciezka.Text) == ".wav")
                {
                    rodzajwyjscie.Text = "Rodzaj pliku: " + rozszerzenie;
                    bity = new StringBuilder();
                    bityRozszerzenie = new StringBuilder();
                    foreach (byte b in bytes)
                    {
                        bity.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
                    }
                    foreach (char ch in rozszerzenie.Substring(1))
                    {
                        bityRozszerzenie.Append(Convert.ToString((int)ch, 2).PadLeft(8, '0'));
                    }
                    daneukryty = new daneUkrytyPlik(File.ReadAllBytes(textBox1.Text), openFileDialog1.FileName.ToString(), Path.GetExtension(textBox1.Text)
                        , bity, bityRozszerzenie);
                    maxPojemnosc = (int)wave.sample * (Convert.ToInt32(comboBox4.SelectedItem.ToString()));
                    pojemnoscNosnika = daneukryty.bity.Length;
                    progressBar1.Maximum = Convert.ToInt32(maxPojemnosc);
                    progressBar1.Value = Convert.ToInt32(pojemnoscNosnika);
                    float pojemnoscProcenty = (float)Math.Round(((float)pojemnoscNosnika / (float)maxPojemnosc) * 100);
                    if (daneukryty == null || daneukryty.bity.Length == 0 || daneukryty.bity == null)
                    {
                        procenty.Text = "0 %";
                        rozmiar.Text = "0 kB";
                    }
                    else
                    {
                        procenty.Text = pojemnoscProcenty.ToString() + "%";
                        rozmiar.Text = Math.Round((Convert.ToDouble(maxPojemnosc) / 8) / 1024, 2) + " / " +
                        Math.Round((Convert.ToDouble(pojemnoscNosnika) / 8) / 1024, 2);
                    }
                }
                else if (Path.GetExtension(sciezka.Text) == ".png" || Path.GetExtension(sciezka.Text) == ".jpeg" || Path.GetExtension(sciezka.Text) == ".jpg")
                {
                    
                    rodzajwyjscie.Text = "Rodzaj pliku: " + rozszerzenie;
                    bity = new StringBuilder();
                    bityRozszerzenie = new StringBuilder();
                    ukrytyZdjecie.ImageLocation = textBox1.Text;
                    foreach (byte b in bytes)
                    {
                        bity.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
                    }
                    foreach (char ch in rozszerzenie.Substring(1))
                    {
                        bityRozszerzenie.Append(Convert.ToString((int)ch, 2).PadLeft(8, '0'));
                    }
                    if (rozszerzenie == ".png" || rozszerzenie == ".jpeg" || rozszerzenie == ".jpg")
                    {
                        daneukryty = new daneUkrytyPlik(File.ReadAllBytes(textBox1.Text), Path.GetExtension(textBox1.Text)
                    , bity, bityRozszerzenie, new Bitmap(textBox1.Text));
                    }
                    else
                    {
                        daneukryty = new daneUkrytyPlik(File.ReadAllBytes(textBox1.Text), openFileDialog1.FileName.ToString(), Path.GetExtension(textBox1.Text)
                    , bity, bityRozszerzenie );
                    }
                    maxPojemnosc = img.Width * img.Height * (Convert.ToInt32(comboBox1.SelectedItem.ToString())
                        + Convert.ToInt32(comboBox2.SelectedItem.ToString()) + Convert.ToInt32(comboBox3.SelectedItem.ToString()));
                    pojemnoscNosnika = daneukryty.bity.Length;
                    progressBar1.Maximum = Convert.ToInt32(maxPojemnosc);
                    progressBar1.Value = Convert.ToInt32(pojemnoscNosnika);
                    float pojemnoscProcenty = (float)Math.Round(((float)pojemnoscNosnika / (float)maxPojemnosc) * 100);
                    if (daneukryty == null || daneukryty.bity.Length == 0 || daneukryty.bity == null)
                    {
                        procenty.Text = "0 %";
                        rozmiar.Text = "0 kB";
                    }
                    else
                    {
                        procenty.Text = pojemnoscProcenty.ToString() + "%";
                        rozmiar.Text = Math.Round((Convert.ToDouble(maxPojemnosc) / 8) / 1024, 2) + " / " +
                        Math.Round((Convert.ToDouble(pojemnoscNosnika) / 8) / 1024, 2);
                        label10.Text = Math.Round(Convert.ToDouble(((img.Width * img.Height * 24) / 8) / 1024), 2).ToString();
                    }
                }
                
            }
        }

        private void wyjscie_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Form aktywnyForm = null;
        
    }
}
