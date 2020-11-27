using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steganografia
{
    class Obraz
    {
        public StringBuilder bity { get; private set; }
        public StringBuilder bityRozszerzenie { get; private set; }
        public Bitmap img { get; private set; }
        public String rozszerzenie { get; private set; }
        public Obraz(Bitmap img, StringBuilder bity, StringBuilder bityRozszerzenie)
        {
            this.img = img;
            this.bity = bity;
            this.bityRozszerzenie = bityRozszerzenie;
        }
        public Obraz(Bitmap img)
        {
            this.img = img;
            this.bity = null;
            this.bityRozszerzenie = null;
        }
        public static byte[] GetBytes(string bitString)
        {
            return Enumerable.Range(0, bitString.Length / 8).
                Select(pos => Convert.ToByte(
                    bitString.Substring(pos * 8, 8),
                    2)
                ).ToArray();
        }
        public Bitmap obrazwObrazie(daneUkrytyPlik daneUkryty, int bityRed, int bityGreen, int bityBlue)
        {
            bool stop = false;
            int przesuniecier = (8 - bityRed);
            int maskaWidocznar = 0xFF << bityRed;
            int maskaNiewidocznar = 0xFF >> przesuniecier;

            int przesuniecieg = (8 - bityGreen);
            int maskaWidocznag = 0xFF << bityGreen;
            int maskaNiewidocznag = 0xFF >> przesuniecieg;

            int przesuniecieb = (8 - bityBlue);
            int maskaWidocznab = 0xFF << bityBlue;
            int maskaNiewidocznab = 0xFF >> przesuniecieb;
            int wartoscq = 0, wartoscw = 0;
            for (int q = 0; q < this.img.Width; q++)
            {
                for (int w = 0; w < this.img.Height; w++)
                {
                    Color pixel = this.img.GetPixel(q, w);
                    if (wartoscw== daneUkryty.img.Height)
                    {
                        wartoscq++;
                        wartoscw = 0;
                    }
                    if (wartoscq == daneUkryty.img.Width)
                    {
                        stop = true;
                        break;
                    }
                    
                    Color pixelend = daneUkryty.img.GetPixel(wartoscq, wartoscw);
                    int r = (pixel.R & maskaWidocznar) + ((pixelend.R >> przesuniecier) & maskaNiewidocznar);
                    int g = (pixel.G & maskaWidocznag) + ((pixelend.G >> przesuniecieg) & maskaNiewidocznag);
                    int b = (pixel.B & maskaWidocznab) + ((pixelend.B >> przesuniecieb) & maskaNiewidocznab);
                    this.img.SetPixel(q, w, Color.FromArgb(r, g, b));
                    wartoscw++;
                }
                if (stop)
                {
                    break;
                }
            }
            return this.img;
        }
        public Bitmap tekstwObrazie(daneUkrytyPlik daneUkryty)
        {
            for (int q = 0; q < img.Width; q++)
            {
                for (int w = 0; w < img.Height; w++)
                {
                    Color pixel = img.GetPixel(q, w);

                    if (q < 1 && w < daneUkryty.bytes.Length)
                    {
                        char letter = Convert.ToChar(daneUkryty.bytes[w]);
                        int value = Convert.ToInt32(letter);
                        img.SetPixel(q, w, Color.FromArgb(pixel.R, pixel.G, value));
                    }
                    if (q == img.Width - 1 && w == img.Height - 1)
                    {
                        img.SetPixel(q, w, Color.FromArgb(pixel.R, pixel.G, daneUkryty.bytes.Length));
                    }
                }
            }
            return this.img;
        }
        public Bitmap dowolnyPlik(int bityRed, int bityGreen, int bityBlue)
        {
            int poz = 0;
            int maskaRed = 0xFF << bityRed, maskaGreen = 0xFF << bityGreen, maskaBlue = 0xFF << bityBlue;
            StringBuilder dlugoscKoncowa = new StringBuilder(), dlugoscPKoncowa = new StringBuilder(), dlugosc2Koncowa = new StringBuilder();
            //Ile pixeli na dlugosc
            dlugoscPKoncowa.Append(Convert.ToString(bity.Length, 2));
            int ilosc = dlugoscPKoncowa.Length;
            int ilePixeli = 0;
            while (ilosc >= 0)
            {
                ilosc -= (bityRed + bityGreen + bityBlue);
                ilePixeli++;
            }
            while ((bityRed + bityGreen + bityBlue) * ilePixeli > dlugoscPKoncowa.Length)
            {
                dlugoscPKoncowa.Insert(0, "0");
            }
            dlugoscKoncowa.Append(Convert.ToString(ilePixeli, 2));
            while ((bityRed + bityGreen + bityBlue) * 2 > dlugoscKoncowa.Length)
            {
                dlugoscKoncowa.Insert(0, "0");
            }
            //
            int ilosc2 = bityRozszerzenie.Length;
            int ilePixeli2 = 0;
            while (ilosc2 >= 0)
            {
                ilosc2 -= (bityRed + bityGreen + bityBlue);
                ilePixeli2++;
            }
            while (bityRozszerzenie.Length % ((bityRed + bityGreen + bityBlue) * ilePixeli2) != 0)
            {
                bityRozszerzenie.Append("0");
            }
            dlugosc2Koncowa.Append(Convert.ToString(ilePixeli2, 2));
            while ((bityRed + bityGreen + bityBlue) * 2 > dlugosc2Koncowa.Length)
            {
                dlugosc2Koncowa.Insert(0, "0");
            }
            //Wartosci
            int IloscZapisanychDlugosci = 0, iloscZapisanychRozszerzenie = 0;
            //int temp = bity.Length - (int)Math.Floor((bity.Length / (bityRed + bityGreen + bityBlue)) * (bityRed + bityGreen + bityBlue) * 1.0);
            String BityWyjsciowe;
            while (bity.Length % (bityRed + bityGreen + bityBlue) != 0)
            {
                bity.Append("0");
            }
            BityWyjsciowe = bity.ToString();
            int dlugoscCalosc = Convert.ToInt32(bity.Length);
            for (int q = 0; q < this.img.Width; q++)
            {
                for (int w = 0; w < this.img.Height; w++)
                {
                    Color pixel = this.img.GetPixel(q, w);
                    if (q == 0 && w <= 1)
                    {
                        int wartoscR = Convert.ToInt32(dlugoscKoncowa.ToString().Substring(poz, bityRed), 2);
                        poz += bityRed;
                        int wartoscG = Convert.ToInt32(dlugoscKoncowa.ToString().Substring(poz, bityGreen), 2);
                        poz += bityGreen;
                        int wartoscB = Convert.ToInt32(dlugoscKoncowa.ToString().Substring(poz, bityBlue), 2);
                        poz += bityBlue;
                        this.img.SetPixel(q, w, Color.FromArgb((pixel.R & maskaRed) + wartoscR, (pixel.G & maskaGreen) + wartoscG
                            , (pixel.B & maskaBlue) + wartoscB));
                        Console.WriteLine(((pixel.R & maskaRed) + wartoscR, (pixel.G & maskaGreen) + wartoscG
                            , (pixel.B & maskaBlue) + wartoscB).ToString());
                        continue;
                    }
                    if (q == 0 && (w == 2 || w == 3))
                    {
                        if (q == 0 && w == 2)
                        {
                            poz = 0;
                        }
                        int wartoscR = Convert.ToInt32(dlugosc2Koncowa.ToString().Substring(poz, bityRed), 2);
                        poz += bityRed;
                        int wartoscG = Convert.ToInt32(dlugosc2Koncowa.ToString().Substring(poz, bityGreen), 2);
                        poz += bityGreen;
                        int wartoscB = Convert.ToInt32(dlugosc2Koncowa.ToString().Substring(poz, bityBlue), 2);
                        poz += bityBlue;
                        this.img.SetPixel(q, w, Color.FromArgb((pixel.R & maskaRed) + wartoscR, (pixel.G & maskaGreen) + wartoscG
                            , (pixel.B & maskaBlue) + wartoscB));
                        continue;
                    }
                    if (IloscZapisanychDlugosci < ilePixeli)
                    {
                        if (IloscZapisanychDlugosci == 0)
                        {
                            poz = 0;
                        }
                        int wartoscR = Convert.ToInt32(dlugoscPKoncowa.ToString().Substring(poz, bityRed), 2);
                        poz += bityRed;
                        int wartoscG = Convert.ToInt32(dlugoscPKoncowa.ToString().Substring(poz, bityGreen), 2);
                        poz += bityGreen;
                        int wartoscB = Convert.ToInt32(dlugoscPKoncowa.ToString().Substring(poz, bityBlue), 2);
                        poz += bityBlue;
                        this.img.SetPixel(q, w, Color.FromArgb((pixel.R & maskaRed) + wartoscR, (pixel.G & maskaGreen) + wartoscG
                            , (pixel.B & maskaBlue) + wartoscB));
                        IloscZapisanychDlugosci++;
                        continue;
                    }
                    if (iloscZapisanychRozszerzenie < ilePixeli2)
                    {
                        if (iloscZapisanychRozszerzenie == 0)
                        {
                            poz = 0;
                        }
                        int wartoscR = Convert.ToInt32(bityRozszerzenie.ToString().Substring(poz, bityRed), 2);
                        poz += bityRed;
                        int wartoscG = Convert.ToInt32(bityRozszerzenie.ToString().Substring(poz, bityGreen), 2);
                        poz += bityGreen;
                        int wartoscB = Convert.ToInt32(bityRozszerzenie.ToString().Substring(poz, bityBlue), 2);
                        poz += bityBlue;
                        this.img.SetPixel(q, w, Color.FromArgb((pixel.R & maskaRed) + wartoscR, (pixel.G & maskaGreen) + wartoscG
                            , (pixel.B & maskaBlue) + wartoscB));
                        iloscZapisanychRozszerzenie++;
                        continue;
                    }
                    if (dlugoscCalosc > 0)
                    {
                        if (dlugoscCalosc == Convert.ToInt32(bity.Length))
                        {
                            poz = 0;
                        }
                        int wartoscR1 = Convert.ToInt32(BityWyjsciowe.ToString().Substring(poz, bityRed), 2);
                        poz += bityRed;
                        int wartoscG1 = Convert.ToInt32(BityWyjsciowe.ToString().Substring(poz, bityGreen), 2);
                        poz += bityGreen;
                        int wartoscB1 = Convert.ToInt32(BityWyjsciowe.ToString().Substring(poz, bityBlue), 2);
                        poz += bityBlue;
                        dlugoscCalosc -= (bityRed + bityGreen + bityBlue);
                        this.img.SetPixel(q, w, Color.FromArgb((pixel.R & maskaRed) + wartoscR1, (pixel.G & maskaGreen) + wartoscG1
                            , (pixel.B & maskaBlue) + wartoscB1));
                        continue;
                    }
                    if (dlugoscCalosc <= 0)
                    {
                        break;
                    }
                }
                if (dlugoscCalosc <= 0)
                {
                    break;
                }
            }
            return this.img;
        }
        public void dekodowanie(int bityRed, int bityGreen, int bityBlue)
        {
            int przesuniecier = (8 - bityRed);
            int maskar = 0xFF >> przesuniecier;

            int przesuniecieg = (8 - bityGreen);
            int maskag = 0xFF >> przesuniecieg;

            int przesuniecieb = (8 - bityBlue);
            int maskab = 0xFF >> przesuniecieb;

            //Wartosci
            StringBuilder vr;
            StringBuilder vg;
            StringBuilder vb;
            int iloscDlugosc = 0, iloscRozszerzenie = 0, dlugoscTemp = 0, Temp1 = 0, Temp2 = 0;
            String iloscPixeliDlugosc = "", iloscPixeliRozszerzenie = "", dlugosc = "", format = "", rozszerzenie = "";
            StringBuilder plik = new StringBuilder();
            byte[] dlugoscRozszerzenieTemp;
            for (int q = 0; q < this.img.Width; q++)
            {
                for (int w = 0; w < this.img.Height; w++)
                {
                    Color pixel = this.img.GetPixel(q, w);
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
                    if (iloscDlugosc > 0)
                    {

                        dlugosc += vr.ToString() + vg.ToString() + vb.ToString();
                        iloscDlugosc--;
                        continue;
                    }

                    if (iloscDlugosc == 0 && w == 4 + Temp1 && q == 0)
                    {
                        dlugoscTemp = Convert.ToInt32(dlugosc, 2);
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
                            String letter = Encoding.ASCII.GetString(new byte[] { Convert.ToByte(b) });
                            rozszerzenie += letter;
                        }
                    }
                    if (dlugoscTemp >= 0)
                    {
                        plik.Append(vr);
                        plik.Append(vg);
                        plik.Append(vb);
                        dlugoscTemp -= (bityRed + bityGreen + bityBlue);
                        continue;
                    }
                    break;
                }
                if (dlugoscTemp <= 0)
                {
                    break;
                }
            }
            this.rozszerzenie = rozszerzenie;
            this.bity = plik;
        }
        public String dekodowanieTekst()
        {
            Color lastpixel = img.GetPixel(img.Width - 1, img.Height - 1);
            int msgLength = lastpixel.B;
            String wiadomosc = "";
            for (int q = 0; q < img.Width; q++)
            {
                for (int w = 0; w < img.Height; w++)
                {
                    Color pixel = img.GetPixel(q, w);
                    if (q < 1 && w < msgLength)
                    {
                        int value = pixel.B;
                        char c = Convert.ToChar(value);
                        String letter = Encoding.ASCII.GetString(new byte[] { Convert.ToByte(c) });
                        Console.WriteLine("letter : " + letter + " value : " + value);
                        wiadomosc = wiadomosc + letter;
                    }
                }
            }
            return wiadomosc;
        }
        public Bitmap dekodowanieObrazu(int bityRed, int bityGreen, int bityBlue)
        {
           
            int przesuniecier = (8 - bityRed);
            int maskar = 0xFF >> przesuniecier;

            int przesuniecieg = (8 - bityGreen);
            int maskag = 0xFF >> przesuniecieg;

            int przesuniecieb = (8 - bityBlue);
            int maskab = 0xFF >> przesuniecieb;

            for (int q = 0; q < img.Width; q++)
            {
                for (int w = 0; w < img.Height; w++)
                {
                    Color pixel = img.GetPixel(q, w);
                    img.SetPixel(q, w, Color.FromArgb((pixel.R & maskar) << przesuniecier, (pixel.G & maskag) << przesuniecieg, (pixel.B & maskab) << przesuniecieb));
                }
            }
            return img;
        }
        
    }
}
