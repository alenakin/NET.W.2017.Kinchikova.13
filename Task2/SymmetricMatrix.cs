using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class SymmetricMatrix<T> : Matrix<T>
    {
        private T[][] angularMatrix;
        
        public int Size { get; }

        public SymmetricMatrix(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException($"{nameof(size)} must be greater than zero.");

            this.Size = size;
            angularMatrix = new T[size][];
            for (int i = 0; i < Size; i++)
            {
                angularMatrix[i] = new T[i + 1];
            }
        }

        public T this[int firstIdx, int secondIdx]
        {
            get
            {
                IndexesValidation(firstIdx, secondIdx);

                return angularMatrix[Math.Max(firstIdx, secondIdx)][Math.Min(firstIdx, secondIdx)];
            }
            set
            {
                IndexesValidation(firstIdx, secondIdx);

                angularMatrix[Math.Max(firstIdx, secondIdx)][Math.Min(firstIdx, secondIdx)] = value;
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
                    result.Append(angularMatrix[Math.Max(i, j)][Math.Min(i, j)] + " ");
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
