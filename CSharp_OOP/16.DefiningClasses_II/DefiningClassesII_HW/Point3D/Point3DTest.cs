using System;

class Point3DTest
{
    static void Main()
    {
        Console.WriteLine(new Point3D(5, 1.5, 99).ToString()+"\n");

        Path points = PathStorage.LoadPathFromFile(@"..\..\SamplePathInput.txt");

        Console.WriteLine("Distance between p({0},{1},{2}) and q({3},{4},{5}) is approx. {6:F6}\r\n",
            points[0].X, points[0].Y, points[0].Z,
            points[1].X, points[1].Y, points[1].Z,
            Distance.Calculate(points[0], points[1]));

        points.Remove(points[0]);
        
        points.Add(new Point3D(101, 5555, 0.1));

        Console.WriteLine("Path coordinates: \r\n" + points.ToString());

        PathStorage.SavePathToFile(points, @"..\..\SamplePathOutput.txt");
    }
}