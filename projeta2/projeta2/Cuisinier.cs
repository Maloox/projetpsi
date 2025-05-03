using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    public class Cuisinier
    {
        private string codeCuisinier;
        private string nomClient;
        private string prenomClient;
        private int telClient;
        private string emailClient;
        private int codePostalClient;
        private int idMetroClient;

        public Cuisinier(string codeCuisinier, string nomClient, string prenomClient, int telClient, string emailClient, int codePostalClient, int idMetroClient)
        {
            this.codeCuisinier = codeCuisinier;
            this.nomClient = nomClient;
            this.prenomClient = prenomClient;
            this.telClient = telClient;
            this.emailClient = emailClient;
            this.codePostalClient = codePostalClient;
            this.idMetroClient = idMetroClient;
        }
        public Cuisinier() : this("N/C", "N/C", "N/C", 0, "N/C", 0, 0)
        {
        }

        public string CodeCuisinier
        {
            get { return codeCuisinier; }
            set { codeCuisinier = value; }
        }

        public string NomClient
        {
            get { return nomClient; }
            set { nomClient = value; }
        }

        public string PrenomClient
        {
            get { return prenomClient; }
            set { prenomClient = value; }
        }

        public int TelClient
        {
            get { return telClient; }
            set { telClient = value; }
        }

        public string EmailClient
        {
            get { return emailClient; }
            set { emailClient = value; }
        }

        public int CodePostalClient
        {
            get { return codePostalClient; }
            set { codePostalClient = value; }
        }

        public int IdMetroClient
        {
            get { return idMetroClient; }
            set { idMetroClient = value; }
        }
    }
}
