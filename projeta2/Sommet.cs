using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    /// <summary>
    /// represente un sommet dans un graphe
    /// </summary>
    internal class Sommet<T>
    {
        private T nom;

        /// <summary>
        /// initialise un sommet avec une valeur donnee
        /// </summary>
        public Sommet(T valeur)
            {
            if (valeur == null)
                throw new ArgumentNullException("Valeur nulle");
            else
                nom = valeur;
            }

        public T Nom
            {get{ return nom; } set{ nom = value; }}
    }
}
