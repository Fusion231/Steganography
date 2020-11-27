using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steganografia
{
    class daneUkrytyPlik
    {
        public byte[] bytes { get; private set; }
        public StringBuilder bity { get; private set; }
        public StringBuilder bityRozszerzenie { get; private set; }
        public String rozszerzenie { get; private set; }
        public String nazwa { get; private set; }
        public Bitmap img { get; private set; }
        public daneUkrytyPlik(byte[] bytes, String nazwa, String rozszerzenie, StringBuilder bity, StringBuilder bityRozszerzenie)
        {
            this.bytes = bytes;
            this.nazwa = nazwa;
            this.rozszerzenie = rozszerzenie;
            this.bity = bity;
            this.bityRozszerzenie = bityRozszerzenie;
            this.img = null;
        }
        public daneUkrytyPlik(byte[] bytes, String rozszerzenie, StringBuilder bity, StringBuilder bityRozszerzenie, Bitmap img)
        {
            this.img = img;
            this.bytes = bytes;
            this.nazwa = nazwa;
            this.rozszerzenie = rozszerzenie;
            this.bity = bity;
            this.bityRozszerzenie = bityRozszerzenie;
        }
        
    }
}
