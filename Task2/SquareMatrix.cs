using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class SquareMatrix<T> : Matrix<T>
    {
        private T[,] values;

        public int Size { get; }

        public SquareMatrix(int size)
        {
            this.Size = size;
            values = new T[size, size];
        }

        public T this[int firstIdx, int secondIdx]
        {
            get
            {
                IndexesValidation(firstIdx, secondIdx);

                return values[firstIdx, secondIdx];
            }
            set
            {
                IndexesValidation(firstIdx, secondIdx);

                values[firstIdx, secondIdx] = value;
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
                    result.Append(values[i, j] + " ");
                }

                result.Append(Environment.NewLine);
            }
            return result.ToString();
        }

        private void IndexesValidation(int firstIdx, int secondIdx)
        {
            if (firstIdx < 0 || secondIdx < 0
                    || firstIdx >= Size || secondIdx >= Size)
            {
                throw new ArgumentOutOfRangeException("Indexes must be in range [0; size of matrix).");
            }
        }
    }
}
