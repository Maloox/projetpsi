using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    public class EstApprovisione
    {
        private string nomP;
        private string reference;
        private string quantite;

        public EstApprovisione(string nomP, string reference, string quantite)
        {
            this.nomP = nomP;
            this.reference = reference;
            this.quantite = quantite;
        }

        public EstApprovisione() : this("N/C", "N/C", "N/C") { }

        public string NomP
        {
            get { return nomP; }
            set { nomP = value; }
        }

        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        public string Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }
    }
}
