using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    public class Ingredient
    {
        private string nomI;

        public Ingredient(string nomI)
        {
            this.nomI = nomI;
        }

        public Ingredient() : this("N/C") { }

        public string NomI
        {
            get { return nomI; }
            set { nomI = value; }
        }
    }
}
