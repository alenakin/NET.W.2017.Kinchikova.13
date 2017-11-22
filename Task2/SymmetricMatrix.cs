using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Represents a square symmetric matrix.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the matrix.</typeparam>
    public class SymmetricMatrix<T> : Matrix<T>
    {
        #region Field
        private T[][] angularMatrix;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates matrix with size x size elements.
        /// </summary>
        /// <param name="size">Size of matrix.</param>
        public SymmetricMatrix(int size) : base(size)
        {
            this.angularMatrix = new T[size][];
            for (int i = 0; i < this.Size; i++)
            {
                this.angularMatrix[i] = new T[i + 1];
            }
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
                    array[i, j] = this.angularMatrix[Math.Max(i, j)][Math.Min(i, j)];
                }
            }

            return array;
        }
        #endregion

        #region Protected methods
        protected override T GetValue(int firstIdx, int secondIdx)
        {
            return this.angularMatrix[Math.Max(firstIdx, secondIdx)][Math.Min(firstIdx, secondIdx)];
        }

        protected override void SetValue(int firstIdx, int secondIdx, T value)
        {
            this.angularMatrix[Math.Max(firstIdx, secondIdx)][Math.Min(firstIdx, secondIdx)] = value;
        }
        #endregion
    }
}
