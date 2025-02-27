using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Timers;

namespace TD1_1
{
    class Program
    {
        static void Main(string[] args)
        {

            void Ex2()
            {
 
                void DessineMoiUneLigne(int dimension)
                {
                    for (int i = 0; i < dimension; i++)
                    {
                        Console.Write("*");
                    }
                }
                void DessineMoiUneMatrice(char symbole, int dimension)
                {
                    for (int i = 0; i < dimension; i++)
                    {
                        for (int j = 0; j < dimension; j++)
                        {
                            Console.Write(symbole);
                        }
                        Console.WriteLine();
                    }
                }
                void DessineMoiUneDiagonale(char symbole, char symboleDiag, int dimension, char direction)
                {
                    if (direction == 'D')
                    {
                        for (int i = 0; i < dimension; i++)
                        {
                            for (int j = 0; j < dimension; j++)
                            {
                                if (i == j)
                                {
                                    Console.Write(symboleDiag);
                                }
                                else
                                {
                                    Console.Write(symbole);
                                }
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dimension; i++)
                        {
                            for (int j = 0; j < dimension; j++)
                            {
                                if (i + j + 1 == dimension)
                                {
                                    Console.Write(symboleDiag);
                                }
                                else
                                {
                                    Console.Write(symbole);
                                }
                            }
                            Console.WriteLine();
                        }
                    }
                }

                int dimension = 4;
                char symbole = 'X';
                char symboleDiag = '1';
                char direction = 'M';
                Console.WriteLine();
                DessineMoiUneLigne(dimension);
                Console.WriteLine();
                Console.WriteLine();
                DessineMoiUneMatrice(symbole, dimension);
                Console.WriteLine();
                DessineMoiUneDiagonale(symbole, symboleDiag, dimension, direction);
            }

            void Ex3()
            {
                void sablier(int hauteur)
                {
                    for (int i = 0; i < hauteur; i++)
                    {
                        for (int j = 0; j < hauteur; j++)
                        {
                            if (j >= i && j < hauteur - i || i >= j && i + j >= hauteur - 1)
                            {
                                Console.Write("X");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                    }
                }

                int hauteur = 7;
                sablier(hauteur);
            }

            void Ex4()
            {
                void AfficherMat(int[,] mat)
                {
                    for (int i = 0; i < mat.GetLength(0); i++)
                    {
                        for (int j = 0; j < mat.GetLength(1); j++)
                        {
                            Console.Write(mat[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                }

                int[,] TableMultiplication(int nombreMax, int multiplicateurMax)
                {
                    if (nombreMax <= 1 || multiplicateurMax <= 1)
                    {
                        return null;
                    }
                    else
                    {
                        int[,] matrice = new int[multiplicateurMax, nombreMax];

                        for (int i = 0; i < matrice.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrice.GetLength(1); j++)
                            {
                                matrice[i, j] = (i + 1) * (j + 1);
                            }
                        }

                        return matrice;
                    }
                }

                int[,] multiplication = TableMultiplication(9, 10);
                AfficherMat(multiplication);
            }

            void Ex5()
            {
                void InverserString(string chaine)
                {
                    string chaineInverse = "";

                    for (int i = chaine.Length - 1; i >= 0; i--)
                    {
                        chaineInverse += chaine[i];
                    }

                    Console.WriteLine(chaineInverse);
                }

                InverserString("test");
            }

            void Ex6()
            {
                Console.WriteLine("Saisissez le mot : ");
                string mot = Console.ReadLine();
                Console.WriteLine("Saisissez la phrase : ");
                string phrase = Console.ReadLine();
                int nb_mot = 1;
                int compteur = 0;

                for (int i = 0; i < phrase.Length; i++)
                {
                    if (phrase[i] == ' ')
                    {
                        nb_mot++;
                    }
                }
                int p = 0;
                for (int i = 0; i < nb_mot; i++)
                {
                    string t = "";
                    while (phrase[p] != ' ' && p != phrase.Length - 1)
                    {
                        t = t + phrase[p];
                        p++;
                    }
                    if (p == phrase.Length - 1)
                    {
                        t = t + phrase[p];
                    }
                    p++;
                    if (t == mot)
                    {
                        compteur++;
                    }
                }
                Console.WriteLine("Voici le nombre de fois que le mot apparaît : " + compteur);
            }


            Console.WriteLine("Menu TD1 Partie 1:");
            Console.WriteLine("Ex2: ");
            Console.WriteLine("Ex3: ");
            Console.WriteLine("Ex4: ");
            Console.WriteLine("Ex5: ");
            Console.WriteLine("Ex6: ");

            ConsoleKeyInfo cki;

            do
            {
                int val = 0;

                while (val == 0)
                {
                    Console.WriteLine("Sélectionnez l'exercice désiré");
                    val = Convert.ToInt32(Console.ReadLine());
                }

                switch (val)
                {
                    case 2:
                        Ex2();
                        break;
                    case 3:
                        Ex3();
                        break;
                    case 4:
                        Ex4();
                        break;
                    case 5:
                        Ex5();
                        break;
                    case 6:
                        Ex6();
                        break;
                    default:
                        Console.WriteLine("Exercice non existant");
                        break;
                }

                Console.WriteLine("Tapez Escape pour sortir ou une autre touche pour continuer");
                
                cki = Console.ReadKey();

            } while (cki.Key != ConsoleKey.Escape);
        }

    }
}

