using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Represents a geometric vector
    /// </summary>
    class Vector
    {
        #region Private fields
        private int _xCoordinate;
        private int _yCoordinate;
        private int _zCoordinate;
        #endregion

        #region Properties
        /// <summary>
        /// Gets vector's coordinate x
        /// </summary>
        public int XCoordinate
        {
            get
            {
                return _xCoordinate;
            }
        }
        /// <summary>
        /// Gets vector's coordinate y
        /// </summary>
        public int YCoordinate
        {
            get
            {
                return _yCoordinate;
            }
        }
        /// <summary>
        /// Gets vector's coordinate z
        /// </summary>
        public int ZCoordinate
        {
            get
            {
                return _zCoordinate;
            }
        }
        /// <summary>
        /// Gets vector's <see cref="Length"/>
        /// </summary>
        public double Length
        {
            get
            {
                return Math.Sqrt(_xCoordinate * _xCoordinate + _yCoordinate * _yCoordinate + _zCoordinate * _zCoordinate);
            }
        }
        #endregion

        #region Construrtors
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class which is given by coordinates x, y, z.
        /// </summary>
        /// <param name="x">Coordinate x</param>
        /// <param name="y">Coordinate y</param>
        /// <param name="z">Coordinate z</param>
        public Vector(int x, int y, int z)
        {
            this._xCoordinate = x;
            this._yCoordinate = y;
            this._zCoordinate = z;
        }
        #endregion

        #region Overloading operators
        public static Vector operator +(Vector first, Vector second)
        {
            int xNew, yNew, zNew;
            xNew = first._xCoordinate + second._xCoordinate;
            yNew = first._yCoordinate + second._yCoordinate;
            zNew = first._zCoordinate + second._zCoordinate;
            return new Vector(xNew, yNew, zNew);
        }
        public static Vector operator -(Vector first, Vector second)
        {
            int xNew, yNew, zNew;
            xNew = first._xCoordinate - second._xCoordinate;
            yNew = first._yCoordinate - second._yCoordinate;
            zNew = first._zCoordinate - second._zCoordinate;
            return new Vector(xNew, yNew, zNew);
        }
        public static Vector operator *(Vector first, Vector second)
        {
            int xNew, yNew, zNew;
            xNew = first._yCoordinate * second._zCoordinate - first._zCoordinate * second._yCoordinate;
            yNew = first._zCoordinate * second._xCoordinate - first._xCoordinate * second._zCoordinate;
            zNew = first._xCoordinate * second._yCoordinate - first._yCoordinate * second._xCoordinate;
            return new Vector(xNew, yNew, zNew);
        }
        public static bool operator ==(Vector first, Vector second)
        {
            return first._xCoordinate == second._xCoordinate && first._yCoordinate == second._yCoordinate && first._zCoordinate == second._zCoordinate;
        }
        public static bool operator !=(Vector first, Vector second)
        {
            return !(first == second);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds of two vectors
        /// </summary>
        /// <param name="vector">Vector to addition</param>
        /// <returns>Returns new vector type of <see cref="Vector"/> that is sum of current vector and specified vector</returns>
        public Vector Add(Vector vector)
        {
            return this + vector;
        }
        /// <summary>
        /// Subtracts of two vectors
        /// </summary>
        /// <param name="vector">Vector to subtraction</param>
        /// <returns>Returns new vector type of <see cref="Vector"/> that is subtraction result of current vector and specified vector</returns>
        public Vector Subtract(Vector vector)
        {
            return this - vector;
        }
        /// <summary>
        /// Scalar products of two vectors
        /// </summary>
        /// <param name="vector">Vecor to scalar production</param>
        /// <returns>Returns number type of <see cref="Int32"/> that is scalar production result of current vector and specified vector</returns>
        public int ScalarProduct(Vector vector)
        {
            return this._xCoordinate * vector._xCoordinate + this._yCoordinate * vector._yCoordinate + 
                this._zCoordinate * vector._zCoordinate;
        }
        /// <summary>
        /// Products of two vectors
        /// </summary>
        /// <param name="vector">Vecor to production</param>
        /// <returns>Returns new vector type of <see cref="Vector"/> that is production result of current vector and specified vector</returns>
        public Vector VectorProduct(Vector vector)
        {
            return this * vector;
        }
        /// <summary>
        /// Mixed products of three vectors
        /// </summary>
        /// <param name="vector2">Vecor to mixed production</param>
        /// <param name="vector3">Vecor to mixed production</param>
        /// <returns>Returns number type of <see cref="Int32"/> that is mixed production result of current vector and specified vectors</returns>
        public int MixedProduct(Vector vector2, Vector vector3)
        {

            return this.ScalarProduct(vector2 * vector3);
        }
        /// <summary>
        /// Calculates angle between two vectors
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <returns>Returns number type of <see cref="Double"/> that is angle between current vector and specified vectors</returns>
        public double CalculateAngle(Vector vector)
        {
            return Math.Acos(this.ScalarProduct(vector) / (this.Length * vector.Length));
        }
        /// <summary>
        /// Determines whether the specified object is equal to the current object. Inherited from <see cref="Object"/>
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <returns>Returhs <see langword="True"/> if objects are equal. Returhs <see langword="False"/> if objects aren't equal.</returns>
        public override bool Equals(Object vector)
        {
            if (this != null && vector != null && vector is Vector)
            {
                return this == (Vector)vector;
            }
            else { return false; }
        }
        /// <summary>
        /// Serves as the default hash function.  Inherited from <see cref="Object"/>
        /// </summary>
        /// <returns>Returns hash code</returns>
        public override int GetHashCode()
        {
            return this._xCoordinate * this._xCoordinate + this._yCoordinate * this._yCoordinate + 
                this._zCoordinate * this._zCoordinate;
        }
        #endregion
    }
}
