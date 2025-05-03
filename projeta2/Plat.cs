using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    public class Plat
    {
        private string nomP;
        private string nbPersonnes;
        private string dateFabrication;
        private string type;
        private string datePeremption;
        private string prix;
        private string regime;
        private string nature;

        // Constructeur complet
        public Plat(string nomP, string nbPersonnes, string dateFabrication, string type, string datePeremption, string prix, string regime, string nature)
        {
            this.nomP = nomP;
            this.nbPersonnes = nbPersonnes;
            this.dateFabrication = dateFabrication;
            this.type = type;
            this.datePeremption = datePeremption;
            this.prix = prix;
            this.regime = regime;
            this.nature = nature;
        }

        // Constructeur par défaut
        public Plat() : this("N/C", "N/C", "N/C", "N/C", "N/C", "N/C", "N/C", "N/C")
        {
        }

        public string NomP
        {
            get { return nomP; }
            set { nomP = value; }
        }

        public string NbPersonnes
        {
            get { return nbPersonnes; }
            set { nbPersonnes = value; }
        }

        public string DateFabrication
        {
            get { return dateFabrication; }
            set { dateFabrication = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string DatePeremption
        {
            get { return datePeremption; }
            set { datePeremption = value; }
        }

        public string Prix
        {
            get { return prix; }
            set { prix = value; }
        }

        public string Regime
        {
            get { return regime; }
            set { regime = value; }
        }

        public string Nature
        {
            get { return nature; }
            set { nature = value; }
        }
    }
}
