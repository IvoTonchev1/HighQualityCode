namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FIleInfo.GetFileExtension("example"));
            Console.WriteLine(FIleInfo.GetFileExtension("example.pdf"));
            Console.WriteLine(FIleInfo.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FIleInfo.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FIleInfo.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FIleInfo.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", DimensionalCalculator.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", DimensionalCalculator.CalcDistance3D(5, 2, -1, 3, -6, 4));

            DimensionalCalculator.Width = 3;
            DimensionalCalculator.Height = 4;
            DimensionalCalculator.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", DimensionalCalculator.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", DimensionalCalculator.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", DimensionalCalculator.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", DimensionalCalculator.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", DimensionalCalculator.CalcDiagonalYZ());
        }
    }
}
