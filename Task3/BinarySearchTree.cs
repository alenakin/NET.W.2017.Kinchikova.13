using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class BinarySearchTree<T>
    {
        private T[] values;
        public int Size { get; }

        public BinarySearchTree(int n)
        {
            Size = n;
            values = new T[n + 1];
        }

        public void Add(T value)
        {
            for (int i = 0; i < Size; i *= 2)
            {

            }
        }

        public void Delete()
        {

        }


    }
}
