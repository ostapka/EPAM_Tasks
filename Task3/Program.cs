using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 1, 2, 3, 4, 5 };
            Vector vector = new Vector(arr, 2, arr.Length + 2);
            int[] arr1 = { 0, 1, 2, 3, 4, 5 };
            Vector vector1 = new Vector(arr1, 2, arr.Length + 2);
            try
            {
                Vector vSum = vector.Add(vector1);
                Console.WriteLine("Result of vectors adding:");
                for (int i = vSum.BottomLimit; i < vSum.TopLimit; i++)
                {
                    Console.Write(vSum[i] + " ");
                }
                Console.WriteLine();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------------");
            try
            {
                Vector vSub = vector - vector1;
                Console.WriteLine("Result of vectors subtraction:");
                for (int i = vSub.BottomLimit; i < vSub.TopLimit; i++)
                {
                    Console.Write(vSub[i] + " ");
                }
                Console.WriteLine();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------------");
            try
            {
                Vector vMul = vector.Multiply(5);
                Console.WriteLine("Result of multiplication vector to number:");
                for (int i = vMul.BottomLimit; i < vMul.TopLimit; i++)
                {
                    Console.Write(vMul[i] + " ");
                }
                Console.WriteLine();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Write("Press any key...");
            Console.ReadKey();
        }
    }
}
