using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class ElementChangedEventArgs<T> : EventArgs
    {
        public int I { get; }
        public int J { get; }
        public T Value { get; }

        public ElementChangedEventArgs(int i, int j, T newValue)
        {
            I = i;
            J = j;
            Value = newValue;
        }
    }
}
