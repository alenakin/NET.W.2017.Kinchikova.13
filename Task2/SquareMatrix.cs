using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Represents a square matrix.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the matrix.</typeparam>
    public class SquareMatrix<T> : Matrix<T>
    {
        #region Field
        private T[,] values;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates matrix with size x size elements.
        /// </summary>
        /// <param name="size">Size of matrix.</param>
        public SquareMatrix(int size) : base(size)
        {
            this.values = new T[size, size];
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Creates array with elements of matrix.
        /// </summary>
        /// <returns>Array with elements of matrix.</returns>
        public override T[,] ToArray()
        {
            return this.values;
        }
        #endregion

        #region Protected methods
        protected override T GetValue(int firstIdx, int secondIdx)
        {
            return this.values[firstIdx, secondIdx];
        }

        protected override void SetValue(int firstIdx, int secondIdx, T value)
        {
            this.values[firstIdx, secondIdx] = value;
        } 
        #endregion
    }
}
