using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    /// <summary>
    /// represente un lien entre deux sommets dans un graphe    
    /// </summary>
    internal class Lien<T>
    {
        private int temps;
        private Sommet<T> sommet1;
        private Sommet<T> sommet2;

        /// <summary>
        /// initialise un nouveau lien entre deux sommets existants
        /// </summary>

        public Lien(Sommet<T> s1, Sommet<T> s2, int temps)
        {
            sommet1 = s1;
            sommet2 = s2;
            this.temps = temps;
        }
        /// <summary>
        /// initialise un nouveau lien entre deux valeurs, en creant les sommets correspondants
        /// </summary>
        public Lien(T valeur1, T valeur2, int temps)
        {
            sommet1 = new Sommet<T>(valeur1);
            sommet2 = new Sommet<T>(valeur2);
            this.temps = temps;
        }

        public int Temps
        { get { return temps; } set {  temps = value; } }

        public Sommet<T> Sommet1
        { get { return sommet1; } set { sommet1 = value; } }

        public Sommet<T> Sommet2
        { get { return sommet2; } set { sommet2 = value; } }


    }
}
