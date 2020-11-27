using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steganografia
{
    class dekodowanieProgram
    {


        public StringBuilder rozszerzenie { get; private set; }
        public uint dlugoscPliku { get; private set; }
        public uint dlugoscRozszerzenia { get; private set; }
        public uint iloscPizeliRozszerzenie { get; private set; }
        public uint iloscPixeliDlugoscPliku { get; private set; }
        public dekodowanieProgram(StringBuilder rozszerzenie)
        {
            this.rozszerzenie = rozszerzenie;
        }
        public void dekodowanie(Bitmap img)
        {
            
        }
    }
}
