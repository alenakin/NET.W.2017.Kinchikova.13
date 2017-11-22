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
    public abstract class Matrix<T>
    {
        #region Constructor
        /// <summary>
        /// Creates matrix with size x size elements.
        /// </summary>
        /// <param name="size">Size of matrix.</param>
        public Matrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(size)} must be greater than zero.");
            }

            Size = size;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Event for changing an element of matrix.
        /// </summary>
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged = delegate { };

        /// <summary>
        /// Size of matrix.
        /// </summary>
        public int Size { get; protected set; }
        #endregion

        #region Public methods
        /// <summary>
        /// Indexator
        /// </summary>
        /// <param name="firstIdx">First index of matrix.</param>
        /// <param name="secondIdx">Second index of matrix.</param>
        /// <returns></returns>
        public T this[int firstIdx, int secondIdx]
        {
            get
            {
                IndexesValidation(firstIdx, secondIdx);
                return GetValue(firstIdx, secondIdx);
            }

            set
            {
                IndexesValidation(firstIdx, secondIdx);
                SetValue(firstIdx, secondIdx, value);
                OnElementChanged(new ElementChangedEventArgs<T>(firstIdx, secondIdx, value));
            }
        }

        /// <summary>
        /// Creates array with elements of matrix.
        /// </summary>
        /// <returns>Array with elements of matrix.</returns>
        public abstract T[,] ToArray();

        /// <summary>
        /// Represents matrix in string.
        /// </summary>
        /// <returns>String representation of matrix.</returns>
        public override string ToString()
        {
            T[,] array = this.ToArray();
            StringBuilder resultStr = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    resultStr.Append(array[i, j] + " ");
                }

                resultStr.Append(Environment.NewLine);
            }

            return resultStr.ToString();
        }
        #endregion

        #region Protected methods
        protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            EventHandler<ElementChangedEventArgs<T>> temp = ElementChanged;
            temp?.Invoke(this, e);
        }

        protected abstract T GetValue(int firstIdx, int secondIdx);

        protected abstract void SetValue(int firstIdx, int secondIdx, T value);
        #endregion

        #region Private methods
        private void IndexesValidation(int firstIdx, int secondIdx)
        {
            if (firstIdx < 0 || secondIdx < 0
                    || firstIdx >= Size || secondIdx >= Size)
            {
                throw new ArgumentOutOfRangeException("Indexes must be in range [0; size of matrix).");
            }
        }
        #endregion
    }
}
