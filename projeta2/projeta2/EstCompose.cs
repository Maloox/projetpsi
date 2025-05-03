using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    public class EstCompose
    {
        private string nomP;
        private string nomI;
        private string quantite;

        public EstCompose(string nomP, string nomI, string quantite)
        {
            this.nomP = nomP;
            this.nomI = nomI;
            this.quantite = quantite;
        }

        public EstCompose() : this("N/C", "N/C", "N/C") { }

        public string NomP
        {
            get { return nomP; }
            set { nomP = value; }
        }

        public string NomI
        {
            get { return nomI; }
            set { nomI = value; }
        }

        public string Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }
    }
}
