using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steganografia
{
    class Sprawdzanie
    {
        private StringBuilder str = new StringBuilder();
        private StringBuilder org = new StringBuilder();
        private StringBuilder vr;
        private StringBuilder vg;
        private StringBuilder vb;
        public void Spr(Bitmap img,int dlugoscCiagu, int br, int bg, int bb)
        {
            int przesuniecier = (8 - br);
            int maskar = 0xFF >> przesuniecier;

            int przesuniecieg = (8 - bg);
            int maskag = 0xFF >> przesuniecieg;

            int przesuniecieb = (8 - bb);
            int maskab = 0xFF >> przesuniecieb;
            for (int q = 0; q < img.Width; q++)
            {
                for (int w = 4; w < img.Height; w++)
                {
                    Color pixel = img.GetPixel(q, w);
                    vr = new StringBuilder();
                    vg = new StringBuilder();
                    vb = new StringBuilder();
                    vr.Append(Convert.ToString(pixel.R & maskar, 2));
                    while (vr.Length % (br) != 0)
                    {
                        vr.Insert(0,"0");
                    }
                    vg.Append(Convert.ToString(pixel.G & maskag, 2));
                    while (vg.Length % (bg) != 0)
                    {
                        vg.Insert(0,"0");

                    }
                    vb.Append(Convert.ToString(pixel.B & maskab, 2));
                    while (vb.Length % (bb) != 0)
                    {
                        vb.Insert(0,"0");
                    }
                    str.Append(vr);
                    str.Append(vg);
                    str.Append(vb);
                    org.Append(Convert.ToString(pixel.R, 2));
                    org.Append(Convert.ToString(pixel.G, 2));
                    org.Append(Convert.ToString(pixel.B, 2));
                    dlugoscCiagu--;
                    if (dlugoscCiagu == 0)
                    {
                        break;
                    }
                }
                if (dlugoscCiagu == 0)
                {
                    break;
                }
            }
            Console.WriteLine(str.ToString() + "\n\r" + org.ToString());

        }
    }
}
