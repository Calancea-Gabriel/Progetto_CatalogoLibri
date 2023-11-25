using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio01.Model
{
    class clsAutori
    {
        private int pIdAutore;
        private string pCognAutore;
        private string pNomeAutore;
        private DateTime pDatNasAutore;
        private string pFotoAutore;
        private char pValAutore;

        public int IdAutore { get => pIdAutore; set => pIdAutore = value; }
        public string CognAutore { get => pCognAutore; set => pCognAutore = value; }
        public string NomeAutore { get => pNomeAutore; set => pNomeAutore = value; }
        public DateTime DatNasAutore { get => pDatNasAutore; set => pDatNasAutore = value; }
        public string FotoAutore { get => pFotoAutore; set => pFotoAutore = value; }
        public char ValAutore { get => pValAutore; set => pValAutore = value; }
    }
}
