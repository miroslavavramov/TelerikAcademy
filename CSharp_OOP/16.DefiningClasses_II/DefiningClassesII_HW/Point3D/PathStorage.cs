using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static class PathStorage
{
    public static Path LoadPathFromFile(string filePath)
    {
        Path path = new Path();

        using (StreamReader reader = new StreamReader(filePath))
        {
            while(true)
            {
                string inputLine = reader.ReadLine();

                if (!string.IsNullOrEmpty(inputLine))
                {
                    double[] pointCoords = inputLine
                        .Split(new char[] { 'X', 'Y', 'Z', ':' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(double.Parse).ToArray();

                    path.Add(new Point3D(pointCoords[0], pointCoords[1], pointCoords[2]));
                }
                else break;
            }
        }

        return path;
    }

    public static void SavePathToFile(Path path, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < path.Count; i++)
            {
                writer.WriteLine(path[i].ToString());
            }
        }
    }
}