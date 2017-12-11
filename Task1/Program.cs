using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector firstVector = new Vector(1, 2, 3);
            Vector secondVector = new Vector(2, 1, -2);
            Vector thirdVector;
            thirdVector = firstVector.VectorProduct(secondVector);
            Console.WriteLine("Result vector: X = {0}, Y = {1}, Z = {2}",
                thirdVector.XCoordinate, thirdVector.YCoordinate, thirdVector.ZCoordinate);
            thirdVector = firstVector - secondVector;
            Console.WriteLine("Result vector: X = {0}, Y = {1}, Z = {2}",
                thirdVector.XCoordinate, thirdVector.YCoordinate, thirdVector.ZCoordinate);
            firstVector = new Vector(3, 1, 2);
            thirdVector = firstVector.Add(secondVector);
            Console.WriteLine("Result vector: X = {0}, Y = {1}, Z = {2}",
                thirdVector.XCoordinate, thirdVector.YCoordinate, thirdVector.ZCoordinate);
            thirdVector = firstVector.Subtract(secondVector);
            Console.WriteLine("Result vector: X = {0}, Y = {1}, Z = {2}",
                thirdVector.XCoordinate, thirdVector.YCoordinate, thirdVector.ZCoordinate);
            int scalarProduct = firstVector.ScalarProduct(thirdVector);
            Console.WriteLine($"Scalar product of vectors a({firstVector.XCoordinate}, {firstVector.YCoordinate}, " +
                $"{firstVector.ZCoordinate}) and b({thirdVector.XCoordinate}, {thirdVector.YCoordinate}, " +
                $"{thirdVector.ZCoordinate}) is equal {scalarProduct}.");
            firstVector = new Vector(1, 0, 3);
            secondVector = new Vector(5, 5, 0);
            thirdVector = new Vector(2, 0, -1);
            int mixedProduct = firstVector.MixedProduct(secondVector, thirdVector);
            Console.WriteLine($"Mixed product of vectors a({firstVector.XCoordinate}, {firstVector.YCoordinate}, " +
                $"{firstVector.ZCoordinate}), b({secondVector.XCoordinate}, {secondVector.YCoordinate}, " +
                $"{secondVector.ZCoordinate}) and c({thirdVector.XCoordinate}, {thirdVector.YCoordinate}, " +
                $"{thirdVector.ZCoordinate}) is equal {mixedProduct}.");
            double angle = firstVector.CalculateAngle(secondVector);
            Console.WriteLine($"Angle between two vectors a({firstVector.XCoordinate}, {firstVector.YCoordinate}, " +
                $"{firstVector.ZCoordinate}) and b({secondVector.XCoordinate}, {secondVector.YCoordinate}, " +
                $"{secondVector.ZCoordinate}) is equal to {angle}");
            Console.WriteLine($"Vector a({firstVector.XCoordinate}, {firstVector.YCoordinate}, " +
                $"{firstVector.ZCoordinate}) length is equal to {firstVector.Length}");
            Console.Write("Press any key...");
            Console.ReadKey();
        }
    }
}
