using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    public class Avis
    {
        private string idRetour;
        private string note;
        private string codeCuisinier;
        private int codeClient;
        private string reference;

        public Avis(string idRetour, string note, string codeCuisinier, int codeClient, string reference)
        {
            this.idRetour = idRetour;
            this.note = note;
            this.codeCuisinier = codeCuisinier;
            this.codeClient = codeClient;
            this.reference = reference;
        }

        public Avis() : this("N/C", "N/C", "N/C", 0, "N/C") { }

        public string IdRetour
        {
            get { return idRetour; }
            set { idRetour = value; }
        }

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        public string CodeCuisinier
        {
            get { return codeCuisinier; }
            set { codeCuisinier = value; }
        }

        public int CodeClient
        {
            get { return codeClient; }
            set { codeClient = value; }
        }

        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }
    }
}
