using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class ElementChangedEventArgs<T> : EventArgs
    {
        public ElementChangedEventArgs(int i, int j, T newValue)
        {
            this.I = i;
            this.J = j;
            this.Value = newValue;
        }

        public int I { get; }

        public int J { get; }

        public T Value { get; }
    }
}
