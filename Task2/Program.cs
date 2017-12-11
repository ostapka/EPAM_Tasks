using System;

namespace Task2
{
    /// <summary>
    /// Represents a point struct
    /// </summary>
    public struct Point
    {
        public double X, Y;
        public Point(double x, double y) { X = x; Y = y; }
        public double Distance(Point p)
        {
            double distance = Math.Sqrt(Math.Pow((X - p.X), 2) + Math.Pow((Y - p.Y), 2));
            return distance;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect1 = new Rectangle(new Point(2, 2), new Point(5, 5));
            Rectangle rect2 = new Rectangle(new Point(3, 3), new Point(4, 4));
            try
            {
                Rectangle rect3 = rect1.GetIntersectionRectangle(rect2);
                if (rect3 != null)
                    Console.WriteLine($"Have rectangle intersection with verteces ({rect3.VertexLeftBottom.X}, {rect3.VertexLeftBottom.Y}) ({rect3.VertexRightTop.X}, {rect3.VertexRightTop.Y})");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Needs to move one of rectangle...");
            }
            Console.Write("Press any key...");
            Console.ReadKey();
        }
    }
}
