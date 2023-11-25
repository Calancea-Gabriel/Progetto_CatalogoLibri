using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio01.Model
{
    class clsEditori
    {
        public int pIdEditore;
        private string pNomeEditore;
        private char pValEditore;
        
        public int IdEditore { get => pIdEditore; set => pIdEditore = value; }
        public string NomeEditore { get => pNomeEditore; set => pNomeEditore = value; }
        public char ValEditore { get => pValEditore; set => pValEditore = value; }
    }
}
