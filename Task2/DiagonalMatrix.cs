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

        public DiagonalMatrix(int size) : base(size)
        {
            diagonal = new T[size];
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

        protected override T getValue(int firstIdx, int secondIdx)
        {
            if (firstIdx == secondIdx)
            {
                return diagonal[firstIdx];
            }
            else
            {
                return default(T);
            }
        }

        protected override void setValue(int firstIdx, int secondIdx, T value)
        {
            if (firstIdx != secondIdx && !value.Equals(default(T)))
            {
                throw new ArgumentOutOfRangeException("Diagonal matrix can't have not " +
                    "default values outside the diagonal.");
            }

            diagonal[firstIdx] = value;
        }
    }
}
