using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    public class Client
    {
        private int codeClient;
        private string nom;
        private string prenom;
        private string rue;
        private int idMetro;
        private int numero;
        private int codePostal;
        private string ville;
        private int tel;
        private string email;

        public Client(int codeClient, string nom, string prenom, string rue, int idMetro, int numero,int codePostal, string ville, int tel, string email)
        {
            this.codeClient = codeClient;
            this.nom = nom;
            this.prenom = prenom;
            this.rue = rue;
            this.idMetro = idMetro;
            this.numero = numero;
            this.codePostal = codePostal;
            this.ville = ville;
            this.tel = tel;
            this.email = email;
           
        }
        public Client() : this(0, "N/C", "N/C", "N/C", 0, 0, 0, "N/C", 0, "N/C")
        {
        }

        public int CodeClient
        {
            get { return codeClient; }
            set { codeClient = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public string Rue
        {
            get { return rue; }
            set { rue = value; }
        }

        public int IdMetro
        {
            get { return idMetro; }
            set { idMetro = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public int CodePostal
        {
            get { return codePostal; }
            set { codePostal = value; }
        }

        public string Ville
        {
            get { return ville; }
            set { ville = value; }
        }

        public int Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        
    }

}
