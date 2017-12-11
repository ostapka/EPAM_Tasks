using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Represents a rectangle
    /// </summary>
    class Rectangle
    {
        #region Private fields
        private Point _vertexLeftBottom, _vertexRightTop;
        #endregion

        #region Properties
        /// <summary>
        /// Gets rectangle's left bottom vertex
        /// </summary>
        public Point VertexLeftBottom
        {
            get { return _vertexLeftBottom; }
        }
        /// <summary>
        /// Gets rectangle's right top vertex
        /// </summary>
        public Point VertexRightTop
        {
            get { return _vertexRightTop; }
        }
        #endregion

        #region Construrtors
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class which is given by opposide vertexes.
        /// </summary>
        /// <param name="vertex1">First vertex</param>
        /// <param name="vertex2">Second vertex</param>
        public Rectangle(Point vertex1, Point vertex2)
        {
            Point vertexLeftBottom, vertexRightTop;
            if(vertex1.X < vertex2.X)
            {
                vertexLeftBottom.X = vertex1.X;
            }
            else
            {
                vertexLeftBottom.X = vertex2.X;
            }
            if (vertex1.Y < vertex2.Y)
            {
                vertexLeftBottom.Y = vertex1.Y;
            }
            else
            {
                vertexLeftBottom.Y = vertex2.Y;
            }
            if (vertex1.X > vertex2.X)
            {
                vertexRightTop.X = vertex1.X;
            }
            else
            {
                vertexRightTop.X = vertex2.X;
            }
            if (vertex1.Y > vertex2.Y)
            {
                vertexRightTop.Y = vertex1.Y;
            }
            else
            {
                vertexRightTop.Y = vertex2.Y;
            }
            this._vertexLeftBottom = vertexLeftBottom;
            this._vertexRightTop = vertexRightTop;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class which is given by vertex and sides length.
        /// </summary>
        /// <param name="vertexStart">Vertex</param>
        /// <param name="sideA">First side length which is parallel to the axis Y</param>
        /// <param name="sideB">Second side length which is parallel to the axis X</param>
        public Rectangle(Point vertexStart, double sideA, double sideB)
        {
            if(sideA > 0 && sideB > 0)
            {
                this._vertexLeftBottom = vertexStart;
                _vertexRightTop.X = sideB + vertexStart.X;
                _vertexRightTop.Y = sideA + vertexStart.Y;
            }
            else if (sideA < 0 && sideB < 0)
            {
                this._vertexRightTop = vertexStart;
                _vertexLeftBottom.X = sideB + vertexStart.X;
                _vertexLeftBottom.Y = sideA + vertexStart.Y;
            }
            else if (sideA < 0 && sideB > 0)
            {
                this._vertexLeftBottom.X = vertexStart.X;
                this._vertexLeftBottom.Y = sideA + vertexStart.Y;
                this._vertexRightTop.X = sideB + vertexStart.X;
                this._vertexRightTop.Y = vertexStart.Y;
            }
            else if (sideA > 0 && sideB < 0)
            {
                this._vertexLeftBottom.X = sideB + vertexStart.X;
                this._vertexLeftBottom.Y = vertexStart.Y;
                this._vertexRightTop.X = vertexStart.X;
                this._vertexRightTop.Y = sideA + vertexStart.Y;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Static method that moves rectangle
        /// </summary>
        /// <param name="rect">Rectangle that is moving</param>
        /// <param name="n">The value at which rectangle should move through axis X</param>
        /// <param name="m">The value at which rectangle should move through axis Y</param>
        public static void Move(ref Rectangle rect, int n, int m)
        {
            rect._vertexLeftBottom.X += n;
            rect._vertexLeftBottom.Y += m;
            rect._vertexRightTop.X += n;
            rect._vertexRightTop.Y += m;
        }
        /// <summary>
        /// Moves rectangle
        /// </summary>
        /// <param name="n">The value at which rectangle should move through axis X</param>
        /// <param name="m">The value at which rectangle should move through axis Y</param>
        /// <returns>Returns current rectangle</returns>
        public Rectangle Move(int n, int m)
        {
            this._vertexLeftBottom.X += n;
            this._vertexLeftBottom.Y += m;
            this._vertexRightTop.X += n;
            this._vertexRightTop.Y += m;
            return this;
        }
        /// <summary>
        /// Scales up rectangle
        /// </summary>
        /// <param name="k">The value at which rectangle should scale up</param>
        /// <returns>Returns current rectangle</returns>
        public Rectangle ChangeSize(double k)
        {
            Point vertex3 = new Point(_vertexLeftBottom.X, _vertexRightTop.Y);
            Point vertex4 = new Point(_vertexRightTop.X, _vertexLeftBottom.Y);
            double sideA = k * _vertexLeftBottom.Distance(vertex3);
            double sideB = k * _vertexLeftBottom.Distance(vertex4);
            Rectangle rectangle = new Rectangle(_vertexLeftBottom, sideA, sideB);
            _vertexRightTop.X = rectangle._vertexRightTop.X;
            _vertexRightTop.Y = rectangle._vertexRightTop.Y;
            return this;
        }
        /// <summary>
        /// Builds the least rectangle that contains current and specified rectangles.
        /// </summary>
        /// <param name="rectangle">Rectangle</param>
        /// <returns>Returns new <see cref="Rectangle"/> that contains current and specified rectangles.</returns>
        public Rectangle LeastRectangle(Rectangle rectangle)
        {
            Point pointLeftBottomNew, pointRightTopNew;
            if(this._vertexLeftBottom.X <= rectangle._vertexLeftBottom.X)
            {
                pointLeftBottomNew.X = this._vertexLeftBottom.X;
            }
            else
            {
                pointLeftBottomNew.X = rectangle._vertexLeftBottom.X;
            }
            if (this._vertexLeftBottom.Y <= rectangle._vertexLeftBottom.Y)
            {
                pointLeftBottomNew.Y = this._vertexLeftBottom.Y;
            }
            else
            {
                pointLeftBottomNew.Y = rectangle._vertexLeftBottom.Y;
            }
            if (this._vertexRightTop.X >= rectangle._vertexRightTop.X)
            {
                pointRightTopNew.X = this._vertexRightTop.X;
            }
            else
            {
                pointRightTopNew.X = rectangle._vertexRightTop.X;
            }
            if (this._vertexRightTop.Y >= rectangle._vertexRightTop.Y)
            {
                pointRightTopNew.Y = this._vertexRightTop.Y;
            }
            else
            {
                pointRightTopNew.Y = rectangle._vertexRightTop.Y;
            }
            Rectangle rectangleNew = new Rectangle(pointLeftBottomNew, pointRightTopNew);
            return rectangleNew;
        }
        /// <summary>
        /// Builds intersection rectangle.
        /// </summary>
        /// <param name="rectangle">Rectangle</param>
        /// <returns>Returns new <see cref="Rectangle"/> that is intersection of current and specified rectangles.</returns>
        public Rectangle GetIntersectionRectangle (Rectangle rectangle)
        {
            Point pointLeftBottomNew, pointRightTopNew;
            List<double> listXCoordinates = new List<double>(4);
            List<double> listYCoordinates = new List<double>(4);
            double[] arrayX = { this._vertexLeftBottom.X, this._vertexRightTop.X, rectangle._vertexLeftBottom.X, rectangle._vertexRightTop.X };
            listXCoordinates.AddRange(arrayX);
            listXCoordinates.Sort();
            double[] arrayY = { this._vertexLeftBottom.Y, this._vertexRightTop.Y, rectangle._vertexLeftBottom.Y, rectangle._vertexRightTop.Y };
            listYCoordinates.AddRange(arrayY);
            listYCoordinates.Sort();
            pointLeftBottomNew.X = listXCoordinates[1];
            pointRightTopNew.X = listXCoordinates[2];
            pointLeftBottomNew.Y = listYCoordinates[1];
            pointRightTopNew.Y = listYCoordinates[2];
            Rectangle rectangleNew = new Rectangle(pointLeftBottomNew, pointRightTopNew);
            bool booleanExpresion1 = rectangleNew._vertexLeftBottom.X == this._vertexLeftBottom.X && rectangleNew._vertexLeftBottom.Y == this._vertexLeftBottom.Y &&
                rectangleNew._vertexRightTop.X == this._vertexRightTop.X && rectangleNew._vertexRightTop.Y == this._vertexRightTop.Y;
            bool booleanExpresion2 = rectangleNew._vertexLeftBottom.X == rectangle._vertexLeftBottom.X && rectangleNew._vertexLeftBottom.Y == rectangle._vertexLeftBottom.Y &&
                rectangleNew._vertexRightTop.X == rectangle._vertexRightTop.X && rectangleNew._vertexRightTop.Y == rectangle._vertexRightTop.Y;
            bool booleanExpresion3 = rectangleNew._vertexLeftBottom.X >= rectangle._vertexLeftBottom.X && rectangleNew._vertexLeftBottom.X <= rectangle._vertexRightTop.X &&
                rectangleNew._vertexRightTop.X >= rectangle._vertexLeftBottom.X && rectangleNew._vertexRightTop.X <= rectangle._vertexRightTop.X;
            bool booleanExpresion4 = rectangleNew._vertexLeftBottom.Y >= rectangle._vertexLeftBottom.Y && rectangleNew._vertexLeftBottom.Y <= rectangle._vertexRightTop.Y &&
                rectangleNew._vertexRightTop.Y >= rectangle._vertexLeftBottom.Y && rectangleNew._vertexRightTop.Y <= rectangle._vertexRightTop.Y;
            bool booleanExpresion5 = booleanExpresion3 && booleanExpresion4;
            if (!booleanExpresion1 && !booleanExpresion2 && booleanExpresion5)
            {
                return rectangleNew;
            }
            throw new ArgumentOutOfRangeException("Rectangles don't have intersection.");
        }
        #endregion
    }
}
