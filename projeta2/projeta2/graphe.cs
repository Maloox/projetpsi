using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    /// <summary>
    /// represente un graphe avec une matrice d'adjacence et une liste d'adjacence
    /// </summary>
    internal class Graphe<T>
    {
        public int[,] matriceadj = null;
        public List<int>[] listeadj= null;
        private int max;

        /// <summary>
        /// initialise un graphe a partir d'une liste de liens
        /// </summary>
        public Graphe(List<Lien<T>> liste)
        {
            
            List<T> liste_sommet = new List<T>();

            foreach (Lien<T> lien in liste)
            {
                Sommet<T> p1 = lien.Sommet1;
                Sommet<T> p2 = lien.Sommet2;
                int temps = lien.Temps;
               
                if (liste_sommet.Contains(p1.Nom)==false && (p1.Nom.ToString() != "0"))
                    liste_sommet.Add(p1.Nom);
                if (liste_sommet.Contains(p2.Nom) == false && (p2.Nom.ToString() != "0"))
                    liste_sommet.Add(p2.Nom);
            }
            int max = liste_sommet.Count();
            
            matriceadj = new int[max,max];
            listeadj = new List<int>[max]; 

            for(int p = 0; p < max; p++)
                listeadj[p] = new List<int>();
            
            foreach (Lien<T> lien in liste)
            {
                Sommet<T> p1 = lien.Sommet1;
                Sommet<T> p2 = lien.Sommet2;
                int temps = lien.Temps;

                if (p1.Nom.ToString() == "0" || p2.Nom.ToString() == "0");

                else
                {
                    matriceadj[liste_sommet.IndexOf(p1.Nom), liste_sommet.IndexOf(p2.Nom)] = temps;
                    listeadj[liste_sommet.IndexOf(p1.Nom)].Add(liste_sommet.IndexOf(p2.Nom));
                }

            }
            
        }

        public int[] BFS(int sommet)
        {
            Queue<int> attente = new Queue<int>();
            
            int[] visite = new int[max]; //0 pour blanc 1 pour jaune 2 pour rouge
            List<int> ordre = new List<int>();

            for (int i = 0; i < max; i++)
            {
                visite[i] = 0;
                
            }
            visite[sommet] = 1;
            attente.Enqueue(sommet);
            while(attente.Count>0)
            {
                int  y = attente.Dequeue();
                ordre.Add(y);
                foreach(int i in listeadj[y-1])
                {
                    if (visite[i-1] == 0)
                    {
                        attente.Enqueue(i);
                        visite[i-1] = 1;
                        
                    }
                }
                visite[y-1] = 2;
            }

            /*
            Console.WriteLine("\nOrdre de visite des sommets:");
            foreach (int noeud in ordre)
            {
                Console.Write(noeud + " ");
            }
            */
            return visite;
        }
        public void DFS(int sommet)
        {
            Stack<int> arrive = new Stack<int>();
            int[] visite = new int[max]; //0 pour blanc 1 pour jaune 2 pour rouge
            List<int> ordre = new List<int>();

            for (int i = 0; i < max; i++)
                visite[i] = 0;
            
            
            arrive.Push(sommet);
            visite[sommet] = 1;
            ordre.Add(sommet);
            while(arrive.Count() > 0)
            {
                int y = arrive.Peek();
                bool trouve = false;
                for(int i = 0; i < max;i++)
                {
                    if (listeadj[y - 1].Contains(i) && visite[i] == 0)
                    {
                        arrive.Push(i);
                        visite[i] = 1;
                        ordre.Add(i);
                        trouve = true;
                        if (visite[i] == 1)
                            Console.WriteLine("Cycle trouvé");
                        
                        break;
                    }      
                }
                if (trouve == false)
                {
                    arrive.Pop();
                    visite[y] = 2;
                }
        
            }
        /*
            Console.WriteLine("\nOrdre de visite des sommets:");
            foreach (int noeud in ordre)
            {
                Console.Write(noeud + " ");
            }
        */
        }
        public bool Connexite()
        {
            bool verif = false;
            int[] visite = new int[max];
            visite = BFS(max-1);
            for(int i = 1; i <= max; ++i)
            {
                for(int j = 0; j < max; ++j)
                {
                    if (visite[j] == i)
                        verif = true;
                }
                if (verif == false)
                    return false;
            }
            return verif;
        }

       
    }
}
