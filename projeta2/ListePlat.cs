using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    public class ListePlat
    {
        private string nom;
        private List<Plat> listeP;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public List<Plat> Liste
        {
            get { return listeP; }
            set { listeP = value; }
        }

        public ListePlat()
        {
            listeP = new List<Plat>();
        }

        public ListePlat(string nom)
        {
            this.nom = nom;
            listeP = new List<Plat>();
        }

        public void Ajouter(Plat p)
        {
            listeP.Add(p);
        }
    }
}
