using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    public class ListeCuisinier
    {
        private string nom;
        private List<Cuisinier> listeC;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public List<Cuisinier> Liste
        {
            get { return listeC; }
            set { listeC = value; }
        }

        public ListeCuisinier()
        {
            listeC = new List<Cuisinier>();
        }

        public ListeCuisinier(string nom)
        {
            this.nom = nom;
            listeC = new List<Cuisinier>();
        }

        public void Ajouter(Cuisinier cuisinier)
        {
            listeC.Add(cuisinier);
        }
    }
}
