using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        private T[] diagonal;
        public int Size { get; }

        public DiagonalMatrix(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException($"{nameof(size)} must be greater than zero.");

            this.Size = size;
            diagonal = new T[size];
        }

        public T this[int firstIdx, int secondIdx]
        {
            get
            {
                IndexesValidation(firstIdx, secondIdx);

                if (firstIdx == secondIdx)
                    return diagonal[firstIdx];
                else
                    return default(T);
            }
            set
            {
                IndexesValidation(firstIdx, secondIdx);

                if (firstIdx != secondIdx)
                    throw new ArgumentOutOfRangeException("");

                diagonal[firstIdx] = value;
                OnElementChanged(new ElementChangedEventArgs<T>(firstIdx, secondIdx, value));
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i == j)
                    {
                        result.Append(diagonal[i] + " ");
                    }
                    else
                    {
                        result.Append(default(T) + " ");
                    }
                }
                result.Append(Environment.NewLine);
            }
            return result.ToString();
        }

        private void IndexesValidation(int firstIdx, int secondIdx)
        {
            if (firstIdx < 0 || secondIdx < 0
                    || firstIdx >= Size || secondIdx >= Size)
                throw new ArgumentOutOfRangeException("Indexes must be in range [0; size of matrix).");
        }
    }
}
