using SkiaSharp;
using System.Globalization;
using System.Text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using SkiaSharp;

namespace projeta2
{
    public class MetroMapGenerator
    {
        static Dictionary<int, (float X, float Y)> stations = new();
        static Dictionary<int, string> stationNames = new();
        static List<(int, int)> connexions = new();
        static HashSet<string> duplicateStations = new();

        public MetroMapGenerator(string stationsFile, string connectionsFile)
        {
            LoadStations(stationsFile);
            LoadConnections(connectionsFile);
        }

        public void LoadStations(string filePath)
        {
            filePath = Path.GetFullPath(filePath);
            using StreamReader fichier = new StreamReader(filePath, Encoding.Latin1);
            fichier.ReadLine();

            while (!fichier.EndOfStream)
            {
                string[] ligne = fichier.ReadLine().Split(';');
                if (ligne.Length < 5) continue;

                int id = int.Parse(ligne[0]);
                string nom = ligne[2];
                float lon = float.Parse(ligne[3], CultureInfo.InvariantCulture);
                float lat = float.Parse(ligne[4], CultureInfo.InvariantCulture);

                float x = (lon - 2.2f) * 12000;
                float y = (48.9f - lat) * 18000;

                if (stationNames.ContainsValue(nom)) duplicateStations.Add(nom);

                stations[id] = (x, y);
                stationNames[id] = nom;
            }
        }

        public void LoadConnections(string filePath)
        {
            filePath = Path.GetFullPath(filePath);
            using StreamReader fichier = new StreamReader(filePath, Encoding.Latin1);
            fichier.ReadLine();

            while (!fichier.EndOfStream)
            {
                string[] ligne = fichier.ReadLine().Split(';');
                if (ligne.Length < 4) continue;

                int id = int.Parse(ligne[0]);
                if (!string.IsNullOrEmpty(ligne[2]))
                {
                    int prev = int.Parse(ligne[2]);
                    if (!connexions.Contains((prev, id)) && !connexions.Contains((id, prev)))
                        connexions.Add((id, prev));
                }
                if (!string.IsNullOrEmpty(ligne[3]))
                {
                    int next = int.Parse(ligne[3]);
                    if (!connexions.Contains((next, id)) && !connexions.Contains((id, next)))
                        connexions.Add((id, next));
                }
            }
        }

        public void DrawMetroMap(string outputFile, List<int> path = null, int[] vertexColors = null)
        {
            float minX = float.MaxValue, minY = float.MaxValue, maxX = float.MinValue, maxY = float.MinValue;
            foreach (var station in stations.Values)
            {
                minX = Math.Min(minX, station.X);
                minY = Math.Min(minY, station.Y);
                maxX = Math.Max(maxX, station.X);
                maxY = Math.Max(maxY, station.Y);
            }

            int width = (int)(maxX - minX + 400);
            int height = (int)(maxY - minY + 400);

            using var bitmap = new SKBitmap(width, height);
            using var canvas = new SKCanvas(bitmap);
            using var paintLine = new SKPaint { Color = SKColors.Black, StrokeWidth = 4 };
            using var paintText = new SKPaint { Color = SKColors.Black };
            using var typeface = SKTypeface.FromFamilyName("Arial");
            using var font = new SKFont(typeface, 14);

            canvas.Clear(SKColors.White);

            foreach (var (a, b) in connexions)
            {
                if (stations.ContainsKey(a) && stations.ContainsKey(b))
                {
                    float x1 = stations[a].X - minX + 200;
                    float y1 = stations[a].Y - minY + 200;
                    float x2 = stations[b].X - minX + 200;
                    float y2 = stations[b].Y - minY + 200;

                    canvas.DrawLine(x1, y1, x2, y2, paintLine);
                }
            }

            if (path != null && path.Count > 1)
            {
                using var pathPaint = new SKPaint { Color = SKColors.Blue, StrokeWidth = 6 };
                for (int i = 0; i < path.Count - 1; i++)
                {
                    int a = path[i];
                    int b = path[i + 1];
                    if (stations.ContainsKey(a) && stations.ContainsKey(b))
                    {
                        float x1 = stations[a].X - minX + 200;
                        float y1 = stations[a].Y - minY + 200;
                        float x2 = stations[b].X - minX + 200;
                        float y2 = stations[b].Y - minY + 200;

                        canvas.DrawLine(x1, y1, x2, y2, pathPaint);
                    }
                }
            }

            HashSet<int> alreadyDrawnLabels = new();

            foreach (var station in stations)
            {
                int stationId = station.Key;
                var basePos = station.Value;

                List<int> overlapping = new();
                foreach (var other in stations)
                {
                    if (Math.Abs(other.Value.X - basePos.X) < 0.01 &&
                        Math.Abs(other.Value.Y - basePos.Y) < 0.01)
                    {
                        overlapping.Add(other.Key);
                    }
                }

                int indexInGroup = overlapping.IndexOf(stationId);
                int groupSize = overlapping.Count;

                float radius = 5;
                float angle = (float)(2 * Math.PI * indexInGroup / groupSize);
                float offsetX = groupSize > 1 ? radius * (float)Math.Cos(angle) : 0;
                float offsetY = groupSize > 1 ? radius * (float)Math.Sin(angle) : 0;

                float x = basePos.X - minX + 200 + offsetX;
                float y = basePos.Y - minY + 200 + offsetY;

                SKColor nodeColor = SKColors.Green;
                if (vertexColors != null && stationId - 1 < vertexColors.Length)
                {
                    int colorCode = vertexColors[stationId - 1];

                    nodeColor = colorCode switch
                    {
                        0 => SKColors.Red,
                        1 => SKColors.Green,
                        2 => SKColors.Blue,
                        3 => SKColors.Orange,
                        4 => SKColors.Purple,
                        _ => SKColors.Gray
                    };
                }

                using var paintCircle = new SKPaint { Color = nodeColor, IsAntialias = true };
                canvas.DrawCircle(x, y, 10, paintCircle);

                if (!alreadyDrawnLabels.Contains(stationId) && overlapping[0] == stationId)
                {
                    float baseX = basePos.X - minX + 200;
                    float baseY = basePos.Y - minY + 200;
                    float labelOffsetX = 15;
                    float labelOffsetY = 5;
                    canvas.DrawText(stationNames[stationId], baseX + labelOffsetX, baseY + labelOffsetY, SKTextAlign.Left, font, paintText);

                    foreach (int id in overlapping)
                        alreadyDrawnLabels.Add(id);
                }
            }



            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            using var stream = File.OpenWrite(outputFile);
            data.SaveTo(stream);

            Console.WriteLine($"✅ Carte enregistrée : {outputFile}");
        }


        public void PrintMatrices()
        {
            Console.WriteLine("\nStations :");
            foreach (var s in stations) Console.WriteLine($"ID: {s.Key}, Name: {stationNames[s.Key]}, X: {s.Value.X}, Y: {s.Value.Y}");

            Console.WriteLine("\nConnexions :");
            foreach (var c in connexions) Console.WriteLine($"{c.Item1} <--> {c.Item2}");

            if (duplicateStations.Count > 0)
            {
                Console.WriteLine("\n⚠️ Stations en double détectées :");
                foreach (var name in duplicateStations) Console.WriteLine(name);
            }
        }
    }
}
