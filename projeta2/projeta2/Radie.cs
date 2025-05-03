using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    public class Radie
    {
        private string codeCl;

        public Radie(string codeCl)
        {
            this.codeCl = codeCl;
        }

        public Radie() : this("N/C") { }

        public string CodeCl
        {
            get { return codeCl; }
            set { codeCl = value; }
        }
    }
}
