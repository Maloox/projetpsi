using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    internal class Lien
    {
        private int sommet1;
        private int sommet2;
        private bool arrete;

        public Lien(List<(int, int)> liste, int personne1, int personne2)
        {
            bool verif = false;
            foreach ((int p1, int p2) in liste)
            {
                if ((personne1 == p1 && personne2 == p2) || (personne1 == p2 && personne2 == p1))
                    verif = true;
            }
            arrete = verif;
            sommet1 = personne1;
            sommet2 = personne2;

        }

        public bool Arrete
            
            { get { return arrete; } set {  arrete = value; } }

        
            
    }
}
