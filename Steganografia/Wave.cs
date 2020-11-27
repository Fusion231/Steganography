using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steganografia
{
    class Wave
    {
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
        private uint kanaly { get; set; }
        public uint probkowanie { get; private set; }
        public uint sample { get; private set; }
        public List<uint> Lista = new List<uint>();
        public byte[] dane { get; private set; }
        public StringBuilder rozszerzenieOdkodowanyplik { get; private set; }
        public StringBuilder bityOdkodowanyplik { get; private set; }
        public static byte[] GetBytes(string bitString)
        {
            return Enumerable.Range(0, bitString.Length / 8).
                Select(pos => Convert.ToByte(
                    bitString.Substring(pos * 8, 8),
                    2)
                ).ToArray();
        }
        public Wave(byte[] plik)
        {
            this.dane = plik;
            kanaly = BitConverter.ToUInt16(plik, 0x16);
            probkowanie = BitConverter.ToUInt16(plik, 0x22); 
            if (probkowanie == 8 || probkowanie == 16)
            {
                sample = (BitConverter.ToUInt32(plik, 0x28)) / (probkowanie / 8);
                int i = 0;
                for (int q = 0;q< sample; q++)
                {
                    switch (probkowanie)
                    {
                        case 8:
                            Lista.Add(plik[0x2E + i]);
                            break;
                        case 16:
                            Lista.Add(BitConverter.ToUInt16(plik,0x2E + i));
                            break;
                    }
                    i += (int)(probkowanie / 8);
                }
            }
            else
            {
                this.Lista = null;
            }
        }
        public void kodowanie(int bitySciezka,StringBuilder bityRozszerzenie, StringBuilder bity)
        {
            int poz = 0;
            int maska = 0;
            if (this.probkowanie == 8)
            {
                maska = 0xFF << bitySciezka;
            }
            else if (this.probkowanie == 16)
            {
                maska = 0xFFF << bitySciezka;
            }
            Console.WriteLine(Convert.ToString(maska, 2));
            StringBuilder dlugoscKoncowa = new StringBuilder(), dlugoscPKoncowa = new StringBuilder(), dlugosc2Koncowa = new StringBuilder();
            dlugoscPKoncowa.Append(Convert.ToString(bity.Length, 2));
            int ilosc = dlugoscPKoncowa.Length;
            int ilePixeli = 0;
            while (ilosc > 0)
            {
                ilosc -= bitySciezka;
                ilePixeli++;
            }
            while (bitySciezka * ilePixeli > dlugoscPKoncowa.Length)
            {
                dlugoscPKoncowa.Insert(0, "0");
            }
            dlugoscKoncowa.Append(Convert.ToString(ilePixeli, 2));
            while (bitySciezka * 3 > dlugoscKoncowa.Length)
            {
                dlugoscKoncowa.Insert(0, "0");
            }
            //
            int ilosc2 = bityRozszerzenie.Length;
            int ilePixeli2 = 0;
            while (ilosc2 > 0)
            {
                ilosc2 -= bitySciezka;
                ilePixeli2++;
            }
            while (bityRozszerzenie.Length % (bitySciezka * ilePixeli2) != 0)
            {
                bityRozszerzenie.Append("0");
            }
            dlugosc2Koncowa.Append(Convert.ToString(ilePixeli2, 2));
            while (bitySciezka > dlugosc2Koncowa.Length)
            {
                dlugosc2Koncowa.Insert(0, "0");
            }
            String BityWyjsciowe;
            /*while (bity.Length % (int)this.probkowanie != 0)
            {
                bity.Append("0");
            }*/
            BityWyjsciowe = bity.ToString();
            int dlugoscCalosc = Convert.ToInt32(bity.Length);
            int IloscZapisanychDlugosci = 0, iloscZapisanychRozszerzenie = 0;
            uint wartoscDoZapisu = 0;
            for (int q = 0; q < sample; q++)
            {
                if (q >= 0 && q <=2)
                {
                    wartoscDoZapisu = (Lista.ElementAt(q) & (uint)maska) + ((uint)Convert.ToInt16(dlugoscKoncowa.ToString().Substring(poz, bitySciezka), 2));
                    poz += bitySciezka;
                    Lista[q] = wartoscDoZapisu;
                    continue;
                }
                if (q == 3)
                {
                    poz = 0;
                    wartoscDoZapisu = (Lista.ElementAt(q) & (uint)maska) + ((uint)Convert.ToInt16(dlugosc2Koncowa.ToString().Substring(poz, bitySciezka), 2));
                    Lista[q] = wartoscDoZapisu;
                    continue;
                }
                if (IloscZapisanychDlugosci < ilePixeli)
                {
                     if (IloscZapisanychDlugosci == 0)
                     {
                         poz = 0;
                     }
                     wartoscDoZapisu = (Lista.ElementAt(q) & (uint)maska) + ((uint)Convert.ToInt16(dlugoscPKoncowa.ToString().Substring(poz, bitySciezka), 2));
                    poz += bitySciezka;
                    Lista[q] = wartoscDoZapisu;
                     IloscZapisanychDlugosci++;
                     continue;
                 }
                 if (iloscZapisanychRozszerzenie < ilePixeli2)
                 {
                     if (iloscZapisanychRozszerzenie == 0)
                     {
                         poz = 0;
                     }
                     wartoscDoZapisu = (Lista.ElementAt(q) & (uint)maska) + ((uint)Convert.ToInt16(bityRozszerzenie.ToString().Substring(poz, bitySciezka), 2));
                    poz += bitySciezka;
                    Lista[q] = wartoscDoZapisu;
                     iloscZapisanychRozszerzenie++;
                     continue;
                 }
                 if (dlugoscCalosc == Convert.ToInt32(bity.Length))
                 {
                     poz = 0;
                 }
                 wartoscDoZapisu = (Lista.ElementAt(q) & (uint)maska) + ((uint)Convert.ToInt16(BityWyjsciowe.ToString().Substring(poz, bitySciezka), 2));
                poz += bitySciezka;
                Lista[q]= wartoscDoZapisu;
                dlugoscCalosc -= bitySciezka;
                if (dlugoscCalosc <= 0)
                {
                    break;
                }
            }
        }
        public void dekodowanie(int bitySciezka)
        {
            StringBuilder wartoscDekodowania, daneDekodowane = new StringBuilder(), rozszerzenie = new StringBuilder();
            int iloscPixeli1 = 0, iloscPixeli2 = 0, dlugoscPliku = 0, Temp1 = 0, Temp2 = 0;
            int maska = 0;
            if (this.probkowanie == 8)
            {
                maska = 0xFF >> (8 - bitySciezka);
            }
            else if (this.probkowanie == 16)
            {
                maska = 0xFFFF >> (16 - bitySciezka);
            }
            for (int q = 0;q<this.Lista.Count;q++)
            {
                wartoscDekodowania = new StringBuilder(Convert.ToString(Lista[q] & maska, 2));
                while (wartoscDekodowania.Length % bitySciezka != 0)
                {
                    wartoscDekodowania.Insert(0,"0");
                }
                if (q >=0 && q <=2)
                {
                    daneDekodowane.Append(wartoscDekodowania);
                    continue;
                }
                if (q == 3)
                {
                    iloscPixeli1 = Convert.ToInt32(daneDekodowane.ToString(), 2);
                    iloscPixeli2 = Convert.ToInt32(wartoscDekodowania.ToString(), 2);
                    Temp1 = Convert.ToInt32(daneDekodowane.ToString(), 2);
                    Temp2 = Convert.ToInt32(wartoscDekodowania.ToString(), 2);
                    daneDekodowane.Clear();
                    continue;
                }
                if (q >= 3 && iloscPixeli1 > 0)
                {
                    daneDekodowane.Append(wartoscDekodowania);
                    iloscPixeli1--;
                    continue;
                }
                if (iloscPixeli2 > 0)
                {
                    if (iloscPixeli1 == 0)
                    {
                        iloscPixeli1 = -2;
                        dlugoscPliku = Convert.ToInt32(daneDekodowane.ToString(), 2);
                        daneDekodowane.Clear();
                    }
                    daneDekodowane.Append(wartoscDekodowania);
                    iloscPixeli2--;
                    continue;
                }
                if (dlugoscPliku > 0)
                {
                    if (iloscPixeli2 == 0)
                    {
                        iloscPixeli2 = -2;
                        byte[] temp = GetBytes(daneDekodowane.ToString());
                        foreach (byte b in temp)
                        {
                            String letter = Encoding.ASCII.GetString(new byte[] { Convert.ToByte(b) });
                            rozszerzenie.Append(letter);
                        }
                        daneDekodowane.Clear();
                    }
                    daneDekodowane.Append(wartoscDekodowania);
                    dlugoscPliku -= bitySciezka;
                }
                else
                {
                    break;
                }

            }
            this.bityOdkodowanyplik = daneDekodowane;
            this.rozszerzenieOdkodowanyplik = rozszerzenie;
        }
        public void Save()
        {
            if (probkowanie == 8 || probkowanie == 16)
            {
                int i = 0;
                for (int n = 0; n < sample; n++)
                {
                    switch (probkowanie)
                    {
                        case 8:
                            dane[0x2E + i] = (byte)Lista[n];
                            break;
                        case 16:
                            dane[0x2E + i] = (byte)(Lista[n] & 0xFF);
                            dane[0x2E + i + 1] = (byte)((Lista[n] >> 8) & 0xFF);
                            break;
                    }
                    i += (int)(probkowanie / 8);
                }
            }
        }
        public string sprawdzenie(int bitySciezka)
        {
            StringBuilder wartoscDekodowania, daneDekodowane = new StringBuilder(), rozszerzenie = new StringBuilder();
            int iloscPixeli1 = 0, iloscPixeli2 = 0, dlugoscPliku = 0, Temp1 = 0, Temp2 = 0;
            int maska = 0;
            if (this.probkowanie == 8)
            {
                maska = 0xFF >> (8 - bitySciezka);
            }
            else if (this.probkowanie == 16)
            {
                maska = 0xFFFF >> (16 - bitySciezka);
            }
            for (int q = 0; q < this.Lista.Count; q++)
            {
                wartoscDekodowania = new StringBuilder(Convert.ToString(Lista[q] & maska, 2));
                while (wartoscDekodowania.Length % bitySciezka != 0)
                {
                    wartoscDekodowania.Insert(0, "0");
                }
                if (q >= 0 && q <= 2)
                {
                    daneDekodowane.Append(wartoscDekodowania);
                    continue;
                }
                if (q == 3)
                {
                    iloscPixeli1 = Convert.ToInt32(daneDekodowane.ToString(), 2);
                    iloscPixeli2 = Convert.ToInt32(wartoscDekodowania.ToString(), 2);
                    daneDekodowane.Clear();
                    continue;
                }
                if (q >= 3 && iloscPixeli1 > 0)
                {
                    daneDekodowane.Append(wartoscDekodowania);
                    iloscPixeli1--;
                    continue;
                }
                if (iloscPixeli2 > 0)
                {
                    if (iloscPixeli1 == 0)
                    {
                        iloscPixeli1 = -2;
                        daneDekodowane.Clear();
                    }
                    daneDekodowane.Append(wartoscDekodowania);
                    iloscPixeli2--;
                    continue;
                }
                    if (iloscPixeli2 == 0)
                    {
                        byte[] temp = GetBytes(daneDekodowane.ToString());
                        foreach (byte b in temp)
                        {
                            String letter = Encoding.ASCII.GetString(new byte[] { Convert.ToByte(b) });
                            rozszerzenie.Append(letter);
                            
                        }
                        if (!extensionsList.Contains(rozszerzenie.ToString()))
                        {
                            return "Status pliku: Nie posiada element zakodowanego";
                        }
                        else
                        {
                            return "Status pliku: Posiada element zakodowany "+ rozszerzenie.ToString();
                        }
                    }
            }
            return "Status pliku: Nie posiada element zakodowanego";
        }
    }
}
