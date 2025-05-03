using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    public class ListeClient
    {
        private string nom;
        private List<Client> listeC;

        public string Nom
        {
            get { return nom; } set { nom = value; }
        }
        public List<Client> Liste
        {
            get{ return listeC; }
            set { listeC = value; }
        }
        public ListeClient()
        {
            listeC = new List<Client>();
        }
        public ListeClient(string nom)
        {
            this.nom = nom;
            listeC = new List<Client>();
        }
        public void Ajouter(Client cl)
        {
            listeC.Add(cl);
        }
    }
}
