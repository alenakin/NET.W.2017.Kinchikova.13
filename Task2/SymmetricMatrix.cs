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

        public SymmetricMatrix(int size) : base(size)
        {
            angularMatrix = new T[size][];
            for (int i = 0; i < Size; i++)
            {
                angularMatrix[i] = new T[i + 1];
            }
        }

        protected override T getValue(int firstIdx, int secondIdx)
        {
            return angularMatrix[Math.Max(firstIdx, secondIdx)][Math.Min(firstIdx, secondIdx)];
        }

        protected override void setValue(int firstIdx, int secondIdx, T value)
        {
            angularMatrix[Math.Max(firstIdx, secondIdx)][Math.Min(firstIdx, secondIdx)] = value;
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
    }
}
