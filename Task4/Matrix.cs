using System;

namespace Task4
{
    /// <summary>
    /// Represents a matrix
    /// </summary>
    class Matrix
    {
        #region Private fields
        private int[,] _array;
        #endregion

        #region Properties
        public int Rows
        {
            get
            {
                return this._array.GetUpperBound(0) + 1;
            }
        }
        public int Columns
        {
            get
            {
                return this._array.Length / Rows;
            }
        }
        #endregion

        #region Indexer
        //Indexator is overloaded for access by indexes
        public int this[int indexI, int indexJ]
        {
            get
            {
                return _array[indexI, indexJ];
            }
        }
        #endregion

        #region Construrtors
        public Matrix(int[,] array)
        {
            this._array = array;
        }
        #endregion

        #region Overloading operators
        public static Matrix operator +(Matrix first, Matrix second)
        {
            if (first.Rows == second.Rows && first.Columns == second.Columns)
            {
                int[,] array = new int[first.Rows, first.Columns];
                for (int i = 0; i < first.Rows; i++)
                {
                    for (int j = 0; j < first.Rows; j++)
                    {
                        array[i, j] = first[i, j] + second[i, j];
                    }
                }
                return new Matrix(array);
            }
            throw new ArgumentOutOfRangeException("Matrices don't have the same limits.");
        }
        public static Matrix operator -(Matrix first, Matrix second)
        {
            if (first.Rows == second.Rows && first.Columns == second.Columns)
            {
                int[,] array = new int[first.Rows, first.Columns];
                for (int i = 0; i < first.Rows; i++)
                {
                    for (int j = 0; j < first.Rows; j++)
                    {
                        array[i, j] = first[i, j] - second[i, j];
                    }
                }
                return new Matrix(array);
            }
            throw new ArgumentOutOfRangeException("Matrices don't have the same limits.");
        }
        public static Matrix operator *(Matrix first, Matrix second)
        {
            if(first.Columns == second.Rows)
            {
                int rowsFirst = first.Rows, columnsFirst = first.Columns;
                int rowsSecond = second.Rows, columnsSecond = second.Columns;
                int[,] array = new int[rowsFirst, columnsSecond];
                for (int i = 0; i < rowsFirst; i++)
                {
                    for (int k = 0; k < columnsSecond; k++)
                    {
                        for (int j = 0; j < columnsFirst; j++)
                        {
                            array[i, k] += first[i, j] * second[j, k];
                        }
                    }
                }
                return new Matrix(array);
            }
            throw new ArgumentOutOfRangeException("Matrices can't be multiplied.");
        }
        public static Matrix operator *(Matrix first, int n)
        {
            int[,] array = new int[first.Rows, first.Columns];
            for (int i = 0; i < first.Rows; i++)
            {
                for(int j = 0; j < first.Columns; j++)
                {
                    array[i, j] = first[i, j] * n;
                }
            }
            return new Matrix(array);
        }
        public static bool operator ==(Matrix first, Matrix second)
        {
            if (first.Rows == second.Rows && first.Columns == second.Columns)
            {
                for (int i = 0; i < first.Rows; i++)
                {
                    for(int j = 0; j < first.Columns; j++)
                    {
                        if (first[i, j] != second[i, j])
                            return false;
                    }
                }
                return true;
            }
            else throw new ArgumentOutOfRangeException("Matrices don't have the same limits.");
        }
        public static bool operator !=(Matrix first, Matrix second)
        {
            return !(first == second);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds of two matrixes
        /// </summary>
        /// <param name="matrix">Matrix to addition</param>
        /// <returns>Returns new matrix type of <see cref="Matrix"/> that is sum of current and specified matrices</returns>
        public Matrix Add(Matrix matrix)
        {
            return this + matrix;
        }
        /// <summary>
        /// Subtracts of two matrixes
        /// </summary>
        /// <param name="matrix">Matrix to subtraction</param>
        /// <returns>Returns new matrix type of <see cref="Matrix"/> that is subtraction result of current and specified matrices</returns>
        public Matrix Subtract(Matrix matrix)
        {
            return this - matrix;
        }
        /// <summary>
        /// Products of two matrixes
        /// </summary>
        /// <param name="matrix">Matrix to prodaction</param>
        /// <returns>Returns new matrix type of <see cref="Matrix"/> that is prodaction result of current and specified matrices</returns>
        public Matrix Product(Matrix matrix)
        {
            return this * matrix;
        }
        /// <summary>
        /// Powers current matrix to number
        /// </summary>
        /// <param name="n">The value at which matrix should power</param>
        /// <returns>Returns new matrix type of <see cref="Matrix"/> that is multiplication to number</returns>
        public Matrix Power(int n)
        {
            return this * n;
        }
        /// <summary>
        /// Transposes matrix
        /// </summary>
        /// <returns>Returns new matrix type of <see cref="Matrix"/> that is transposed</returns>
        public Matrix Transpose()
        {
            int[,] array = new int[this.Columns, this.Rows];
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    array[j, i] = this[i, j];
                }
            }
            return new Matrix(array);
        }
        /// <summary>
        /// Get submatrix
        /// </summary>
        /// <param name="n">Numbers of rows</param>
        /// <param name="m">Numbers of colums</param>
        /// <returns>Returns matrix type of <see cref="Matrix"/> in size n x m</returns>
        public Matrix GetSubmatrix(int n, int m)
        {
            if(n <= this.Rows && m <= this.Columns)
            {
                int[,] array = new int[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        array[i, j] = this[i, j];
                    }
                }
                return new Matrix(array);
            }
            throw new ArgumentOutOfRangeException("Submatrix can't be more than original matrix.");
        }
        /// <summary>
        /// Determines whether the specified object is equal to the current object. Inherited from <see cref="Object"/>
        /// </summary>
        /// <param name="matrix">Matrix</param>
        /// <returns>Returhs <see langword="True"/> if objects are equal. Returhs <see langword="False"/> if objects aren't equal.</returns>
        public override bool Equals(Object matrix)
        {
            if (this != null && matrix != null && matrix is Matrix)
            {
                return this == (Matrix)matrix;
            }
            else { return false; }
        }
        /// <summary>
        /// Serves as the default hash function.  Inherited from <see cref="Object"/>
        /// </summary>
        /// <returns>Returns hash code</returns>
        public override int GetHashCode()
        {
            return this[0, 0];
        }
        #endregion
    }
}
