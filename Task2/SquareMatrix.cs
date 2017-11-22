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

        public SquareMatrix(int size) : base(size)
        {
            values = new T[size, size];
        }

        protected override T getValue(int firstIdx, int secondIdx)
        {
            return values[firstIdx, secondIdx];
        }

        protected override void setValue(int firstIdx, int secondIdx, T value)
        {
            values[firstIdx, secondIdx] = value;
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
    }
}
