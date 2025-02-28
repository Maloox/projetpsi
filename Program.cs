
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

using projeta2;
using SkiaSharp;

class Program
{
    static void Main()
    {
        string chemin = "C:\\Users\\gerva\\OneDrive - De Vinci\\Bureau\\soc-karate.mtx";
        List<(int personne1, int personne2)> matrice = new List<(int, int)>();

        
            using (StreamReader fichier = new StreamReader(chemin))
            {
                string line = "";
               
                while ((line = fichier.ReadLine()) != null && line.StartsWith("%")) { }

                
                while ((line = fichier.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');

                    
                    if (parts.Length >= 2)
                    {
                    int personne1 = int.Parse(parts[0]);
                    int personne2 = int.Parse(parts[1]);


                    matrice.Add((personne1, personne2));
                }

                    
                }
            }
 /*
        foreach ((int personne1,int personne2) in matrice)  
            Console.WriteLine(personne1 + " " + personne2);
*/
        Graphe graphe = new Graphe(matrice);
        int[,] adjacencyMatrix = graphe.matriceadj;

        // Taille de l'image
        int width = 1200;
        int height = 1200;

        // Créer une surface de dessin SkiaSharp
        using (var surface = SKSurface.Create(new SKImageInfo(width, height)))
        {
            SKCanvas canvas = surface.Canvas;
            canvas.Clear(SKColors.White); // Fond blanc

            // Nombre de nœuds
            int n = 34;
            
            // Rayon du cercle pour positionner les nœuds
            float radius = Math.Min(width, height) * 0.4f;
            SKPoint center = new SKPoint(width / 2, height / 2);

            // Positions des nœuds (pour les arêtes)
            SKPoint[] nodePositions = new SKPoint[n];
            for (int i = 0; i < n; i++)
            {
                float angle = (float)(2 * Math.PI * i / n);
                nodePositions[i] = new SKPoint(
                    center.X + radius * (float)Math.Cos(angle),
                    center.Y + radius * (float)Math.Sin(angle)
                );
            }

            // Positions des étiquettes (légèrement décalées vers l'extérieur)
            SKPoint[] labelPositions = new SKPoint[n];
            float labelOffset = 20f; // Distance de décalage des étiquettes
            for (int i = 0; i < n; i++)
            {
                float angle = (float)(2 * Math.PI * i / n);
                labelPositions[i] = new SKPoint(
                    center.X + (radius + labelOffset) * (float)Math.Cos(angle),
                    center.Y + (radius + labelOffset) * (float)Math.Sin(angle)
                );
            }

            // Peinture pour les arêtes (lignes épaisses et noires)
            using (var edgePaint = new SKPaint { Color = SKColors.Black, StrokeWidth = 2, IsAntialias = true })
            {
                // Dessiner les arêtes (basées sur nodePositions)
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (adjacencyMatrix[i, j] == 1)
                        {
                            canvas.DrawLine(nodePositions[i], nodePositions[j], edgePaint);
                        }
                    }
                }
            }

            // Peinture pour les numéros des sommets (de 1 à 34)
            using (var textPaint = new SKPaint
            {
                Color = SKColors.Blue,
                TextSize = 16,
                IsAntialias = true,
                TextAlign = SKTextAlign.Center
            })
            {
                // Dessiner les numéros des sommets (basés sur labelPositions)
                for (int i = 0; i < n; i++)
                {
                    canvas.DrawText((i + 1).ToString(), labelPositions[i].X, labelPositions[i].Y, textPaint);
                }
            }

            // Sauvegarder l'image
            using (var image = surface.Snapshot())
            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
            using (var stream = System.IO.File.OpenWrite("graph.png"))
            {
                data.SaveTo(stream);
                Console.WriteLine("Image sauvegardée sous 'graph.png'");
            }
        }



    }

    /*
    for(int i = 0; i < matadj.GetLength(0); i++)
    {
        for(int j = 0; j < matadj.GetLength(1); j++)
            Console.Write(matadj[i,j]);
        Console.WriteLine();
    }

    List<int>[] list = graphe.listeadj;
    for(int i = 0; i < list.Length ; i++)
    {
        if (list[i] != null)
        {
            Console.Write(i+1 + " : ");
            for (int j =0;j<list[i].Count;j++)
            {
                Console.Write(list[i][j]+" ");
            }
            Console.WriteLine();
        }
    } 

    Console.Write(graphe.Connexite());

    graphe.DFS(5);
    */
}
    
