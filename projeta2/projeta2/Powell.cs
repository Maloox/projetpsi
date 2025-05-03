using System;
using System.Linq;

public class WelshPowell
{
    private int[,] matriceAdjacence;
    private int[] degres;
    private int[] couleurs;
    
    public WelshPowell(int[,] matriceAdjacenceOriente)
    {
        this.matriceAdjacence = ConvertirEnNonOriente(matriceAdjacenceOriente);
        int n = matriceAdjacence.GetLength(0);
        degres = new int[n];
        couleurs = new int[n];
    }

    
    static int[,] ConvertirEnNonOriente(int[,] matriceOriente)
    {
        int n = matriceOriente.GetLength(0);
        int[,] matriceNonOriente = new int[n, n];


        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {

                if (matriceOriente[i, j] > 0 || matriceOriente[j, i] > 0)
                {
                    matriceNonOriente[i, j] = 1;
                    matriceNonOriente[j, i] = 1;
                }
            }
        }
        return matriceNonOriente;
    }

    
    public int[] ColorGraph()
    {
        int n = matriceAdjacence.GetLength(0);       
        for (int i = 0; i < n; i++)
            couleurs[i] = -1;
               
        for (int i = 0; i < n; i++)
        {
            degres[i] = 0;
            for (int j = 0; j < n; j++)
            {
                if (matriceAdjacence[i, j] == 1)
                    degres[i]++;
            }
        }       
        var sommetsTries = Enumerable.Range(0, n).OrderByDescending(i => degres[i]).ToArray();        
        foreach (var sommet in sommetsTries)
        {            
            var couleursVoisins = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (matriceAdjacence[sommet, i] == 1 && couleurs[i] != -1)
                    couleursVoisins[couleurs[i]] = true;
            }           
            int couleur = 0;
            while (couleursVoisins[couleur])
                couleur++;          
            couleurs[sommet] = couleur;
        }
        return couleurs;
    }
   
    public void PrintColors()
    {
        for (int i = 0; i < couleurs.Length; i++)
        {
            Console.WriteLine($"Sommet {i} -> Couleur {couleurs[i]}");
        }
    }
}
