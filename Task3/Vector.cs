using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Represents a algebraic vector
    /// </summary>
    class Vector
    {
        #region Private fields
        private int[] _array;
        private int _bottomLimit, _topLimit;
        #endregion

        #region Properties
        /// <summary>
        /// Vector's bottom limit of index
        /// </summary>
        public int BottomLimit
        {
            get
            {
                return _bottomLimit;
            }
        }
        /// <summary>
        /// Vector's top limit of index
        /// </summary>
        public int TopLimit
        {
            get
            {
                return _topLimit;
            }
        }
        #endregion

        #region Indexer
        //Indexator is overloaded for access by index
        public int this[int index]
        {
            get
            {
                if (index >= _bottomLimit && index < _topLimit)
                    return _array[index - _bottomLimit];
                else throw new IndexOutOfRangeException("Index out of range");
            }
        }
        #endregion

        #region Construrtors
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class.
        /// </summary>
        /// <param name="array">Single-dimention array which creates vector</param>
        /// <param name="limit1">Vector's bottom limit of index</param>
        /// <param name="limit2">Vector's top limit of index</param>
        public Vector(int[] array, int limit1, int limit2)
        {
            this._array = array;
            this._bottomLimit = limit1;
            this._topLimit = limit2;
        }
        #endregion

        #region Overloading operators
        public static Vector operator +(Vector first, Vector second)
        {
            int[] array = new int[first._topLimit - first._bottomLimit];
            if (first._bottomLimit == second._bottomLimit && first._topLimit == second._topLimit)
            {
                for (int i = first._bottomLimit; i < first._topLimit; i++)
                {
                    array[i - first._bottomLimit] = first[i] + second[i];
                }
                return new Vector(array, first._bottomLimit, first._topLimit);
            }
            else throw new ArgumentOutOfRangeException("Vectors don't have the same limits.");
        }
        public static Vector operator -(Vector first, Vector second)
        {
            int[] array = new int[first._topLimit - first._bottomLimit];
            if (first._bottomLimit == second._bottomLimit && first._topLimit == second._topLimit)
            {
                for (int i = first._bottomLimit; i < first._topLimit; i++)
                {
                    array[i - first._bottomLimit] = first[i] - second[i];
                }
                return new Vector(array, first._bottomLimit, first._topLimit);
            }
            else throw new ArgumentOutOfRangeException("Vectors don't have the same limits.");
        }
        public static Vector operator *(Vector vector, int n)
        {
            int[] array = new int[vector._topLimit - vector._bottomLimit];
            for (int i = vector._bottomLimit; i < vector._topLimit; i++)
            {
                array[i - vector._bottomLimit] = vector[i] * n;
            }
            return new Vector(array, vector._bottomLimit, vector._topLimit);
        }
        public static bool operator ==(Vector first, Vector second)
        {
            if (first._bottomLimit == second._bottomLimit && first._topLimit == second._topLimit)
            {
                for (int i = first._bottomLimit; i < first._topLimit; i++)
                {
                    if (first[i] != second[i])
                        return false;
                }
                return true;
            }
            else throw new ArgumentOutOfRangeException("Vectors don't have the same limits.");
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
        /// Multiplays of vector to number
        /// </summary>
        /// <param name="n">Number to multiplication</param>
        /// <returns>Returns new vector type of <see cref="Vector"/> that is multiplication result of current vector and specified number</returns>
        public Vector Multiply(int n)
        {
            return this * n;
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
            return this[_bottomLimit];
        }
        #endregion
    }
}
