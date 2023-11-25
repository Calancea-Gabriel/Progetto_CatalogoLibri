using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio01.Model
{
    class clsLibri
    {
        private int pIdLibro;
        private string pTitLibro;
        private string pImgLibro;
        private decimal pPrzLibro;
        private DateTime pDataLibro;
        private int pNPagLibro;
        private string pCodRepLibro;
        private int pIdOffLibro;
        private int pEdiLibro;
        private char pValReparto;

        public int IdLibro { get => pIdLibro; set => pIdLibro = value; }
        public string TitLibro { get => pTitLibro; set => pTitLibro = value; }
        public string ImgLibro { get => pImgLibro; set => pImgLibro = value; }
        public decimal PrzLibro { get => pPrzLibro; set => pPrzLibro = value; }
        public DateTime DataLibro { get => pDataLibro; set => pDataLibro = value; }
        public int NPagLibro { get => pNPagLibro; set => pNPagLibro = value; }
        public string CodRepLibro { get => pCodRepLibro; set => pCodRepLibro = value; }
        public int IdOffLibro { get => pIdOffLibro; set => pIdOffLibro = value; }
        public int IdEdiLibro { get => pEdiLibro; set => pEdiLibro = value; }
        public char ValLibro { get => pValReparto; set => pValReparto = value; }

    }
}
