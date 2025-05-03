using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    public class EstCuisine
    {
        private string nomP;
        private string codeCuisinier;
        private int quantite;

        public EstCuisine(string nomP, string codeCuisinier, int quantite)
        {
            this.nomP = nomP;
            this.codeCuisinier = codeCuisinier;
            this.quantite = quantite;
        }

        public EstCuisine() : this("N/C", "N/C", 0) { }

        public string NomP
        {
            get { return nomP; }
            set { nomP = value; }
        }

        public string CodeCuisinier
        {
            get { return codeCuisinier; }
            set { codeCuisinier = value; }
        }

        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }
    }
}
