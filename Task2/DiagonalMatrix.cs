using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Represents a square diagonal matrix.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the matrix.</typeparam>
    public class DiagonalMatrix<T> : Matrix<T>
    {
        #region Field
        private T[] diagonal;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates matrix with size x size elements.
        /// </summary>
        /// <param name="size">Size of matrix.</param>
        public DiagonalMatrix(int size) : base(size)
        {
            this.diagonal = new T[size];
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Creates array with elements of matrix.
        /// </summary>
        /// <returns>Array with elements of matrix.</returns>
        public override T[,] ToArray()
        {
            T[,] array = new T[Size, Size];
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    if (i == j)
                    {
                        array[i, j] = this.diagonal[i];
                    }
                    else
                    {
                        array[i, j] = default(T);
                    }
                }
            }

            return array;
        }
        #endregion

        #region Protected methods
        protected override T GetValue(int firstIdx, int secondIdx)
        {
            if (firstIdx == secondIdx)
            {
                return this.diagonal[firstIdx];
            }
            else
            {
                return default(T);
            }
        }

        protected override void SetValue(int firstIdx, int secondIdx, T value)
        {
            if (firstIdx != secondIdx && !value.Equals(default(T)))
            {
                throw new ArgumentOutOfRangeException("Diagonal matrix can't have not " +
                    "default values outside the diagonal.");
            }

            this.diagonal[firstIdx] = value;
        }
        #endregion
    }
}
