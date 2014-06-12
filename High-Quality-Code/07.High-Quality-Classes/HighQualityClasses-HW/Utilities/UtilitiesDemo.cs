namespace CohesionAndCoupling
{
    using System;
    using Shapes;
    using Utilities;

    public class UtilitiesDemo
    {
        private static void Main()
        {
            Console.WriteLine(FilesystemUtilities.GetFileExtension("example"));
            Console.WriteLine(FilesystemUtilities.GetFileExtension("example.pdf"));
            Console.WriteLine(FilesystemUtilities.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FilesystemUtilities.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FilesystemUtilities.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FilesystemUtilities.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                GeometryUtilities.CalculateDistance2D(1, -2, 3, 4));

            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                GeometryUtilities.CalculateDistance3D(5, 2, -1, 3, -6, 4));

            var cuboid = new Cuboid(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", cuboid.CalculateVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", cuboid.CalculateDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", cuboid.CalculateDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", cuboid.CalculateDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", cuboid.CalculateDiagonalYZ());
        }
    }
}
