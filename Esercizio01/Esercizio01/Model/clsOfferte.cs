using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio01.Model
{
    class clsOfferte
    {
        private int pIdOfferta;
        private string pDesOfferta;
        private int pScontoOfferta;
        private char pValOfferta;

        public int IdOfferta { get => pIdOfferta; set => pIdOfferta = value; }
        public string DesOfferta { get => pDesOfferta; set => pDesOfferta = value; }
        public int ScontoOfferta { get => pScontoOfferta; set => pScontoOfferta = value; }
        public char ValOfferta { get => pValOfferta; set => pValOfferta = value; }
    }
}
