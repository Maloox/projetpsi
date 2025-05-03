using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    public class EstCommande
    {
        private string nomP;
        private int codeClient;
        private string idCommande;
        private int quantite;

        public EstCommande(string nomP, int codeClient, string idCommande, int quantite)
        {
            this.nomP = nomP;
            this.codeClient = codeClient;
            this.idCommande = idCommande;
            this.quantite = quantite;
        }

        public EstCommande() : this("N/C", 0, "N/C", 0) { }

        public string NomP
        {
            get { return nomP; }
            set { nomP = value; }
        }

        public int CodeClient
        {
            get { return codeClient; }
            set { codeClient = value; }
        }

        public string IdCommande
        {
            get { return idCommande; }
            set { idCommande = value; }
        }

        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }
    }
}
