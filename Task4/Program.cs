using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr1 = new int[,] { { 11, -1 }, { 2, 0 }, { 3, 0 } };
            int[,] arr2 = new int[,] { { 1, 1 }, { 2, 0 } };
            int[,] arr3 = new int[,] { { 10, 10 }, { 25, 10 } };
            Matrix m1 = new Matrix(arr1);
            Matrix m2 = new Matrix(arr2);
            Matrix m3 = new Matrix(arr3);
            try
            {
                Matrix mSum = m2 + m3;
                Console.WriteLine("Result of matrices adding:");
                for (int i = 0; i < mSum.Rows; i++)
                {
                    for (int j = 0; j < mSum.Columns; j++)
                    {
                        Console.Write("{0}\t", mSum[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------------");
            try
            {
                Matrix mSub = m3.Subtract(m2);
                Console.WriteLine("Result of matrices subtraction:");
                for (int i = 0; i < mSub.Rows; i++)
                {
                    for (int j = 0; j < mSub.Columns; j++)
                    {
                        Console.Write("{0}\t", mSub[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------------");
            try
            {
                Matrix mMul = m1.Product(m2);
                Console.WriteLine("Result of matrices multiplication:");
                for (int i = 0; i < mMul.Rows; i++)
                {
                    for (int j = 0; j < mMul.Columns; j++)
                    {
                        Console.Write("{0}\t", mMul[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Result of multiplication matrix to number:");
            Matrix mPow = m1.Power(5);
            for (int i = 0; i < mPow.Rows; i++)
            {
                for (int j = 0; j < mPow.Columns; j++)
                {
                    Console.Write("{0}\t", mPow[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Transpose matrix:");
            Matrix mTrans = mPow.Transpose();
            for (int i = 0; i < mTrans.Rows; i++)
            {
                for (int j = 0; j < mTrans.Columns; j++)
                {
                    Console.Write("{0}\t", mTrans[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------------------");
            try
            {
                Matrix mSubm = m1.GetSubmatrix(2, 2);
                Console.WriteLine("Submatrix:");
                for (int i = 0; i < mSubm.Rows; i++)
                {
                    for (int j = 0; j < mSubm.Columns; j++)
                    {
                        Console.Write("{0}\t", mSubm[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------------");
            Console.Write("Press any key...");
            Console.ReadKey();
        }
    }
}
